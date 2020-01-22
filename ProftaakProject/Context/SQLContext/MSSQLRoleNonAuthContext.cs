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

        public bool Update(int userId, int roleId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE dbo.User_Role SET Role_Id = @Role_Id WHERE User_Id = @User_Id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@User_Id", userId);
                        cmd.Parameters.AddWithValue("@Role_Id", roleId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                connection.Close();
                return false;
            }
        }

        public Role GetByUserId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                Role rol = new Role();
                using (SqlCommand cmd = new SqlCommand("SELECT Role_Id From User_Role Where User_Id = @User_Id", connection))
                {
                    cmd.Parameters.AddWithValue("@User_Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rol.Id = Convert.ToInt32(reader["Role_Id"]);
                        }
                    }
                    return rol;
                }
            }

        }
    }
}
