using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ProftaakProject.Context.SQLContext
{
    public class PostContext : IPostContext
    {

        private readonly string _connectionString;

        public PostContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Create(Post post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Post (titel, datum, inhoud, type, imageFile) output inserted.postID VALUES (@titel, @datum, @inhoud, @type, @imageFile)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@titel", post.Titel);
                        cmd.Parameters.AddWithValue("@datum", post.Datum);
                        cmd.Parameters.AddWithValue("@inhoud", post.Inhoud);
                        cmd.Parameters.AddWithValue("@type", post.TypeId);
                        cmd.Parameters.Add("@imageFile", sqlDbType: SqlDbType.VarBinary).Value = post.ImageFile;
                        //            //cmd.Parameters.AddWithValue("@uitzendID", 1);
                        //            //cmd.Parameters.AddWithValue("@accountID", 1);
                        post.Id = (int)cmd.ExecuteScalar();
                        if (post.Id > -1)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                connection.Close();
                return false;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM dbo.Post WHERE postID = @postID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@postID", id);
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

        public Post GetByID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Post Where PostID = @PostID", connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@PostID", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Post p = new Post(id);
                            while (reader.Read())
                            {
                                p.Id = id;
                                p.Titel = reader["titel"].ToString();
                                p.Datum = (DateTime)reader["datum"];
                                p.Inhoud = reader["inhoud"].ToString();
                                p.TypeId = (int)reader["type"];
                                p.ImageFile = (byte[])reader["imageFile"];
                            }
                            return p;
                        }
                        else
                        {
                            return new Post(-1);
                        }
                    }
                }
            }
        }

        public List<Post> GetAll()
        {
            List<Post> posts = new List<Post>();
            string query = "SELECT * FROM dbo.Post";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            posts.Add(new Post(
                                (int)reader["postId"],
                                reader["titel"].ToString(),
                                reader["inhoud"].ToString(),
                                (int)reader["type"],
                                (byte[])reader["imageFile"]));
                        }
                    }
                }

                connection.Close();
            }

            return posts;
        }

        public bool Update(Post post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE dbo.Post SET titel = @titel , datum = @datum ,inhoud = @inhoud, imageFile = @imageFile  WHERE postID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", post.Id);
                        cmd.Parameters.AddWithValue("@titel", post.Titel);
                        cmd.Parameters.AddWithValue("@datum", post.Datum);
                        cmd.Parameters.AddWithValue("@inhoud", post.Inhoud);
                        cmd.Parameters.Add("@imageFile", sqlDbType: SqlDbType.VarBinary).Value = post.ImageFile;
                        //            //cmd.Parameters.AddWithValue("@uitzendID", 1);
                        //            //cmd.Parameters.AddWithValue("@accountID", 1);
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
    }
}
