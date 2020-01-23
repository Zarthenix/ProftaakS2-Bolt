using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.SQLContext
{
    public class MSSQLReactieContext : IReactieContext
    {
        private readonly string _connectionString;

        public MSSQLReactieContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool Create(Reactie reactie)
        {
            string query;
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                query = "INSERT INTO Reactie (datum, inhoud, postID, gezienDoorGebruiker, accountID) VALUES (@datum, @inhoud, @vraagID, 0, @accountID)";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@datum", reactie.Datum);
                cmd.Parameters.AddWithValue("@inhoud", reactie.Inhoud);
                cmd.Parameters.AddWithValue("@vraagID", reactie.PostID);
                cmd.Parameters.AddWithValue("@accountID", reactie.Auteur.Id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            connection.Close();
            return false;
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM dbo.Reactie WHERE reactieID = @reactieID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@reactieID", id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    return false;
                }
            }
        }

        public List<Reactie> GetAll(int postID)
        {
            List<Reactie> reactieLijst = new List<Reactie>();
            string query = "SELECT reactieID,inhoud,datum,postId,gezienDoorGebruiker,a.accountID,naam FROM dbo.Reactie r inner join dbo.Account a on a.accountID = r.accountID WHERE postID = @postID ORDER BY datum DESC";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue(@"postID", postID);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reactieLijst.Add(new Reactie(
                            (int)reader["reactieID"],
                            reader["inhoud"].ToString(),
                            (DateTime)reader["datum"],
                            (int)reader["postId"],
                            Convert.ToBoolean(reader["gezienDoorGebruiker"]),
                            new Account((int)reader["accountID"], reader["naam"].ToString())
                            ));
                    }
                }
                connection.Close();
            }
            return reactieLijst;
        }

        public Reactie GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool ReactieGelezen(int reactieID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE dbo.Reactie SET gezienDoorGebruiker = 1 WHERE dbo.Reactie.reactieID = @reactieID;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@reactieID", reactieID);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    return false;
                }
            }
        }

        public bool Update(Reactie reactie)
        {
            throw new NotImplementedException();
        }
    }
}
