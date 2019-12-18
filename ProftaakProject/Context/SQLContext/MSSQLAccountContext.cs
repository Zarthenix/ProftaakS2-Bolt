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
                                ac.Id = id;
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
    }
}
