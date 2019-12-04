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
    }
}
