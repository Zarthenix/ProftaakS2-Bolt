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

        public bool AbonnerenOpTag(int tagId, int accId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO dbo.AccountTag (tagID, accountID) VALUES(@tagID, @accID)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@accID", accId);
                        cmd.Parameters.AddWithValue("@tagID", tagId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
        public bool AbonnerenTagOpzeggen(int tagId, int accId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM dbo.AccountTag WHERE tagID = @tagID AND accountID = @accID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@accID", accId);
                        cmd.Parameters.AddWithValue("@tagID", tagId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
        public bool IsGeabonneerdOpTag(int tagId, int accId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM dbo.AccountTag WHERE tagID= @tagID AND accountID = @accID";
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@tagID", tagId);
                    sqlCommand.Parameters.AddWithValue("@accID", accId);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        public List<Tag> GetAllGeabonneerdeTags(int accId)
        {
            var tagList = new List<Tag>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM dbo.AccountTag " +
                    "INNER JOIN dbo.Tag ON dbo.Tag.tagID = dbo.AccountTag.tagID " +
                    "WHERE dbo.AccountTag.accountID = @accID";
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@accID", accId);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tagList.Add(new Tag((int)reader["tagID"], reader["naam"].ToString()));
                            }
                            return tagList;
                        }
                        else
                        {
                            return tagList;
                        }
                    }
                }
            }
        }
    }
}

