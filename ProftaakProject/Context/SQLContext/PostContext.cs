﻿using ProftaakProject.Context.Interfaces;
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
                connection.Open();

                string query = "insert into Post (titel, datum, inhoud) output inserted.postID values (@titel, @datum, @inhoud)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@titel", post.Titel);
                    cmd.Parameters.AddWithValue("@datum", post.Datum);
                    cmd.Parameters.AddWithValue("@inhoud", post.Inhoud);
                    //cmd.Parameters.AddWithValue("@type", post.ty);
                    //cmd.Parameters.AddWithValue("@uitzendID", 1);
                    //cmd.Parameters.AddWithValue("@accountID", 1);

                    post.Id = (int)cmd.ExecuteScalar();
                    if(post.Id > -1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /*public Post Update(Post post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "update (titel, inhoud) from Topic set (@titel, @inhoud) where postID = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", post.Id);
                    cmd.Parameters.AddWithValue("@titel", post.Titel);
                    cmd.Parameters.AddWithValue("@inhoud", post.Inhoud);

                    cmd.ExecuteNonQuery();
                }
                return post;
            }
        }

        public Post Delete(int id)
        {
           using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "delete PostID Topic (titel, datum, inhoud, type, uitzendID, accountID) values (@titel, @datum, @inhoud, @type, @uitzendID, @accountID)";
                using (SqlCommand cmd = new SqlCommand("CreateProduct", connection))
                {
                    cmd.Parameters.AddWithValue("@titel", id.Titel);
                    cmd.Parameters.AddWithValue("@datum", id.Datum);
                    cmd.Parameters.AddWithValue("@inhoud", id.Inhoud);
                    cmd.Parameters.AddWithValue("@type", id.ty);

                    id.Id = (int)cmd.ExecuteScalar();
                }
                return id;
            }
        }*/

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
                                p.Titel = reader["titel"].ToString();
                                p.Datum = (DateTime)reader["datum"];
                                p.Inhoud = reader["inhoud"].ToString();
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
                            posts.Add(new Post((int)reader["postId"], reader["titel"].ToString(), reader["inhoud"].ToString()));
                        }
                    }
                }

                connection.Close();
            }

            return posts;
        }
    }
}