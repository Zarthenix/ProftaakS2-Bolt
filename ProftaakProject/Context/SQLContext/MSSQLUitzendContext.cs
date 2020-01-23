using Microsoft.Extensions.Configuration;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.SQLContext
{
    public class MSSQLUitzendContext : IUitzendContext
    {
        private readonly string _connectionString;

        public MSSQLUitzendContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Create(Uitzendbureau ub)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "insert into Uitzendbureau (naam, eigenaar) output inserted.uitzendID values (@naam, @eigenaar)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@naam", ub.Naam);
                    //cmd.Parameters.AddWithValue("@eigenaar", ub.Eigenaar);
                    cmd.Parameters.AddWithValue("@eigenaar", 1);

                    ub.Id = (int)cmd.ExecuteScalar();
                    if (ub.Id > -1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool Update(Uitzendbureau ub)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "update Uitzendbureau set naam = @naam where uitzendID = @uitzendID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@naam", ub.Naam);
                    cmd.Parameters.AddWithValue("@uitzendID", ub.Id);
                    cmd.ExecuteNonQuery();
                }
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "UPDATE dbo.Account SET uitzendID = null WHERE uitzendID = @uitzendID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@uitzendID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "delete Uitzendbureau where uitzendID = @uitzendID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@uitzendID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<Uitzendbureau> GetAll()
        {
            List<Uitzendbureau> ubs = new List<Uitzendbureau>();
            string query = "SELECT * FROM dbo.Uitzendbureau";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ubs.Add(new Uitzendbureau((int)reader["uitzendId"], reader["naam"].ToString(), (int)reader["eigenaar"]));
                        }
                    }
                }

                connection.Close();
            }

            return ubs;
        }

        public Uitzendbureau GetByID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Uitzendbureau Where uitzendID = @uitzendID", connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@uitzendID", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Uitzendbureau ub = new Uitzendbureau(id);
                            while (reader.Read())
                            {
                                ub.Naam = reader["naam"].ToString();
                                ub.Eigenaar = (int)reader["eigenaar"];
                            }
                            return ub;
                        }
                        else
                        {
                            return new Uitzendbureau(-1);
                        }
                    }
                }
            }
        }

        public bool VoegToeAccountUitzend(int uitzend, string gebruikersnaam)
        {
            string query = "Update Account Set uitzendID = @uitzendID where gebruikersnaam = @gebruikersnaam";
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@uitzendID", uitzend);
                        cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
                        //cmd.ExecuteNonQuery();
                        cmd.ExecuteScalar();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<Account> GetUitzendAccounts(int id)
        {
            List<Account> accs = new List<Account>();
            string query = "SELECT * FROM dbo.Account where uitzendID = @uitzendID";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@uitzendID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accs.Add(new Account((int)reader["accountId"], reader["gebruikersnaam"].ToString(), reader["emailadres"].ToString(), reader["naam"].ToString(), reader["wachtwoord"].ToString()));
                        }
                    }
                }

                connection.Close();
            }

            return accs;
        }

        public bool VerwijderAccountUitzend(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "Update Account Set uitzendID = NULL Where accountID = @accountID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@accountID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public Uitzendbureau GetByAccountID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("Select * from Uitzendbureau where uitzendID = (Select uitzendID from Account where accountID = @accountID)", connection))
                {
                    sqlCommand.Parameters.AddWithValue("@accountID", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Uitzendbureau ub = new Uitzendbureau((int) reader["uitzendID"],
                                    reader["naam"].ToString(), (int) reader["eigenaar"]);
                                return ub;
                            }
                        }
                        return null;
                    }
                }
            }
        }
    }
}
