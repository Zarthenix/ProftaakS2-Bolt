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
    public class MSSQLRoleNonAuthContext : IRoleContext
    {
        private string _connectionString;
        public MSSQLRoleNonAuthContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Role> GetAllRole()
        {
            List<Role> roles = new List<Role>();
            string query = "SELECT * FROM [Role]";
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Role rol = new Role()
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Naam = reader["Name"].ToString()
                                };
                                roles.Add(rol);
                          
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return roles;
        }
    }
}
