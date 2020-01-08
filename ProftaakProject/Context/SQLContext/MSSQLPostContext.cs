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
    public class MSSQLPostContext : IPostContext
    {

        private readonly string _connectionString;

        public MSSQLPostContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Create(Post post)
        {
            string query;
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    if (post.ImageFile != null)
                    {
                        query = "INSERT INTO Post (titel, datum, inhoud, type, aantalBekeken, tagID, imageFile, uitzendID, goedgekeurdDoor) output inserted.postID VALUES (@titel, @datum, @inhoud, @type, @aantalBekeken, @tagID, @imageFile, @uitzendID, @goedgekeurdDoor)";
                    }
                    else { query = "INSERT INTO Post (titel, datum, inhoud, type, aantalBekeken, tagID, uitzendID, goedgekeurdDoor) output inserted.postID VALUES (@titel, @datum, @inhoud, @type, @aantalBekeken, @tagID, @uitzendID, @goedgekeurdDoor)"; }
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@titel", post.Titel);
                        cmd.Parameters.AddWithValue("@datum", DateTime.Now);
                        cmd.Parameters.AddWithValue("@inhoud", post.Inhoud);
                        cmd.Parameters.AddWithValue("@type", post.TypeId);
                        cmd.Parameters.AddWithValue("@aantalBekeken", 0);
                        cmd.Parameters.AddWithValue("@tagID", post.Tag.Id);
                        if (post.ImageFile != null) { cmd.Parameters.Add("@imageFile", sqlDbType: SqlDbType.VarBinary).Value = post.ImageFile; }
                        if (post.Uitzendbureau != null) { cmd.Parameters.AddWithValue("@uitzendID", post.Uitzendbureau.Id); }
                        else { cmd.Parameters.AddWithValue("@uitzendID", 0); }
                        cmd.Parameters.AddWithValue("@goedgekeurdDoor", post.GoedgekeurdDoor);
                        //cmd.Parameters.AddWithValue("@uitzendID", 1);
                        //cmd.Parameters.AddWithValue("@accountID", 1);
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
                string query = "SELECT " +
                    "Tag.tagID, Tag.naam as tagNaam, " +
                    "Post.postID, Post.titel, Post.datum, Post.inhoud, Post.type, Post.goedgekeurdDoor, Post.aantalBekeken, Post.accountID, Post.imageFile, " +
                    "Uitzendbureau.uitzendID, Uitzendbureau.naam as uitzendNaam, Uitzendbureau.eigenaar " +
                    "FROM dbo.Tag " +
                    "INNER JOIN dbo.Post ON dbo.Tag.tagID = dbo.Post.tagID " +
                    "LEFT JOIN dbo.Uitzendbureau on Post.uitzendID = Uitzendbureau.uitzendID " +
                    "Where PostID = @PostID";
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@PostID", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Post p = new Post();
                            while (reader.Read())
                            {
                                p.Id = id;
                                p.Titel = reader["titel"].ToString();
                                p.Datum = (DateTime)reader["datum"];
                                p.Inhoud = reader["inhoud"].ToString();
                                p.TypeId = (int)reader["type"];
                                p.AantalBekenen = (int)reader["aantalBekeken"];
                                if (p.TypeId == 0)
                                {
                                    p.Tag = new Tag((int)reader["tagID"], reader["tagNaam"].ToString());
                                    p.ImageFile = (byte[])reader["imageFile"];
                                }
                                if (reader["uitzendID"].ToString() != "")
                                {
                                    p.Uitzendbureau = new Uitzendbureau((int)reader["uitzendID"], reader["uitzendNaam"].ToString(), (int)reader["eigenaar"]);
                                }
                            }
                            return p;
                        }
                        else
                        {
                            return new Post();
                        }
                    }
                }
            }
        }

        public List<Post> GetAllArtikelen()
        {
            List<Post> posts = new List<Post>();
            string query = "SELECT * FROM dbo.Tag T INNER JOIN dbo.Post p ON T.tagID = p.tagID WHERE type = 0 AND goedgekeurdDoor > 0 ORDER BY P.datum DESC";
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
                                new Tag((int)reader["tagID"], reader["naam"].ToString()),
                                (int)reader["goedgekeurdDoor"],
                                (byte[])reader["imageFile"]));
                        }
                    }
                }
                connection.Close();
            }
            return posts;
        }

        public List<Post> FAQVragenByTag(Tag tag)
        {
            List<Post> posts = new List<Post>();
            string query = "SELECT Top(3) * FROM dbo.Post WHERE tagID = @tagID AND dbo.Post.type = 1 ORDER BY dbo.Post.aantalBekeken DESC";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@tagID", tag.Id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            posts.Add(new Post(
                                (int)reader["postId"],
                                reader["titel"].ToString(),
                                reader["inhoud"].ToString(),
                                (int)reader["type"],
                                tag,
                                (int)reader["goedgekeurdDoor"]));
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
                    string query = "UPDATE dbo.Post SET titel = @titel , datum = @datum ,inhoud = @inhoud, imageFile = @imageFile, uitzendID = @uitzendID  WHERE postID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", post.Id);
                        cmd.Parameters.AddWithValue("@titel", post.Titel);
                        cmd.Parameters.AddWithValue("@datum", post.Datum);
                        cmd.Parameters.AddWithValue("@inhoud", post.Inhoud);
                        cmd.Parameters.AddWithValue("@uitzendID", post.Uitzendbureau.Id);
                        cmd.Parameters.Add("@imageFile", sqlDbType: SqlDbType.VarBinary).Value = post.ImageFile;
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

        public bool IncrementViews(int postID)
        {
            int aantalBekeken = GetByID(postID).AantalBekenen + 1;
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE dbo.Post SET aantalBekeken = @aantalBekeken WHERE postID = @postID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@postID", postID);
                        cmd.Parameters.AddWithValue("@aantalBekeken", aantalBekeken);
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

        public Post SearchResult(string search)
        {
            //type 0 = artikel
            //type 1 = vraag
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Post WHERE inhoud LIKE '%@search%'";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@search", search);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();

                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
            Post p = new Post();
            return p;
        }

        public List<Post> GetAllArtikelenGoedkeuren()
        {
            List<Post> posts = new List<Post>();
            string query = "SELECT * FROM dbo.Tag INNER JOIN dbo.Post ON dbo.Tag.tagID = dbo.Post.tagID WHERE type = 0 AND goedgekeurdDoor = 0";
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
                                new Tag((int)reader["tagID"], reader["naam"].ToString()),
                                (int)reader["goedgekeurdDoor"],
                                (byte[])reader["imageFile"]));
                        }
                    }
                }
                connection.Close();
            }
            return posts;
        }

        public bool UpdateGoedgekeurd(int accId, int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE dbo.Post SET goedgekeurdDoor = @goedgekeurd WHERE postID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@goedgekeurd", accId);
                        cmd.Parameters.AddWithValue("@id", postId);
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
    }
}
