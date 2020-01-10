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
    public class MSSQLTagContext : ITagContext
    {
        private readonly string _connectionString;

        public MSSQLTagContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Tag> GetAll()
        {
            List<Tag> tags = new List<Tag>();
            string query = "SELECT * FROM dbo.Tag";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tags.Add(new Tag((int)reader["tagID"], reader["naam"].ToString()));
                        }
                    }
                }
                connection.Close();
            }
            return tags;
        }

        public List<Tag> GetAllByUserID(int id)
        {
            List<Tag> tags = new List<Tag>();
            string query = "SELECT * FROM dbo.Tag";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tags.Add(new Tag((int)reader["tagID"], reader["naam"].ToString()));
                        }
                    }
                }
                connection.Close();
            }
            return tags;
        }
        public Tag GetTagByID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM dbo.Tag  Where tagID = @tagID";
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@tagID", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return new Tag(id, reader["naam"].ToString());
                        }
                        else
                        {
                            return new Tag();
                        }
                    }
                }
            }
        }
    }
}
