using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.SQLContext
{
    public class MSSQLAccountContext : IAccountContext
    {
        private readonly string _connectionString;

        public MSSQLAccountContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool VoegToeUitzend(int uitzend, string gebruikersnaam)
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
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<Account> GetAllUitzend(int id)
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

        public List<Account> GetAll()
        {
            List<Account> accs = new List<Account>();
            string query = "SELECT * FROM dbo.Account";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accs.Add(new Account((int)reader["accountId"], reader["gebruikersnaam"].ToString(), reader["emailadres"].ToString(), reader["naam"].ToString()));
                        }
                    }
                }

                connection.Close();
            }

            return accs;
        }

        public Account GetByID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Account Where accountID = @accountID", connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@accountID", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Account ac = new Account();
                            while (reader.Read())
                            {
                                ac.Naam = reader["naam"].ToString();
                                ac.Email = reader["emailadres"].ToString();
                                ac.Gebruikersnaam = reader["gebruikersnaam"].ToString();
                                ac.Geslacht = (Gender)reader["geslacht"];
                                //ac.Geboortedatum = (DateTime)reader["geboortedatum"];
                                //ac.Rol = (int)reader["eigenaar"];
                            }
                            return ac;
                        }
                        else
                        {
                            return new Account();
                        }
                    }
                }
            }
        }

        public bool VerwijderUitzend(int id)
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
    }
}
