using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.SQLContext
{
    public class AccountContext : IAccountContext
    {
        private readonly string _connectionString;

        public AccountContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool VoegToeUitzend(int uitzend, int accId)
        {
            string query = "Update Account Set uitzendID = @uitzendID where accountID = @accountID";
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@uitzendID", uitzend);
                        cmd.Parameters.AddWithValue("@accountID", accId);
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

        public List<Account> GetAll(int id)
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
                            accs.Add(new Account((int)reader["accountId"], reader["naam"].ToString(), reader["emailadres"].ToString(), reader["gebruikersnaam"].ToString()));
                        }
                    }
                }

                connection.Close();
            }

            return accs;
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
