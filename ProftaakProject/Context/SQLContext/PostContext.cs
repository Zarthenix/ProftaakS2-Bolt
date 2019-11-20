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

        public Post Create(Post post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "insert into Topic (titel, datum, inhoud, type, uitzendID, accountID) values (@titel, @datum, @inhoud, @type, @uitzendID, @accountID)";
                using (SqlCommand cmd = new SqlCommand("CreateProduct", connection))
                {
                    cmd.Parameters.AddWithValue("@titel", post.Titel);
                    cmd.Parameters.AddWithValue("@datum", post.Datum);
                    cmd.Parameters.AddWithValue("@inhoud", post.Inhoud);
                    //cmd.Parameters.AddWithValue("@type", post.ty);
                    cmd.Parameters.AddWithValue("@uitzendID", 1);
                    cmd.Parameters.AddWithValue("@accountID", 1);

                    post.Id = (int)cmd.ExecuteScalar();
                }
                return post;
            }
        }

        public Post Update(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "update (titel, datum, inhoud, type, uitzendID, accountID) from Topic values (@titel, @datum, @inhoud, @type, @uitzendID, @accountID)";
                using (SqlCommand cmd = new SqlCommand("CreateProduct", connection))
                {
                    cmd.Parameters.AddWithValue("@titel", id.Titel);
                    cmd.Parameters.AddWithValue("@datum", id.Datum);
                    cmd.Parameters.AddWithValue("@inhoud", id.Inhoud);
                    cmd.Parameters.AddWithValue("@uitzendID", 1);
                    cmd.Parameters.AddWithValue("@accountID", 1);

                    id.Id = (int)cmd.ExecuteScalar();
                }
                return id;
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
        }

        public Post GetByID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM v_Products(@productid)", connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@productid", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {


                        if (reader.HasRows)
                        {
                            Post post = new Post(id);
                            while (reader.Read())
                            {
                                post.ProductName = reader["ProductName"].ToString();
                                if (!reader.IsDBNull(reader.GetOrdinal("ProductCalories")))
                                {
                                    post.ProductCalories = (int)reader["ProductCalories"];
                                }
                                else { post.ProductCalories = 0; }
                                post.ProductDescription = reader["ProductDescription"].ToString();
                                post.ProductPrice = (decimal)reader["ProductPrice"];
                                post.ProductImage = (byte[])reader["ProductImg"];
                            }
                            return post;
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
            DataSet sqlDataSet = new DataSet();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Topic]", connection))
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(sqlDataSet);
                }
            }

            foreach (DataRow dr in sqlDataSet.Tables[0].Rows)
            {
                if (posts.Where(p => p.Id == (long)dr["PostID"]).ToList().Count == 0)
                {
                    Post post = new Post()
                    {
                        Id = (int)dr["PostID"],
                        Titel = dr["titel"].ToString(),
                        Datum = dr["ProductDescription"].ToString(),
                        Type = (decimal)dr["type"],
                        ProductImage = (byte[])dr["ProductImg"],
                        ProductCategories = new List<string>()
                    };
                    post.ProductCategories.Add(dr["ProductCategoryName"].ToString());
                    if (!dr.IsNull("ProductCalories"))
                    {
                        post.ProductCalories = (int)dr["ProductCalories"];
                    }
                    else { post.ProductCalories = 0; }

                    posts.Add(post);
                }
                else
                {
                    posts.FirstOrDefault(id => id.Id == (long)dr["PostID"]).ProductCategories.Add(dr["ProductCategoryName"].ToString());
                }
            }
            return posts;

        }
    }
}
