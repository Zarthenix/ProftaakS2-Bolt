﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.SQLContext
{
    public class MSSQLReactieContext : IReactieContext
    {
        private readonly string _connectionString;

        public MSSQLReactieContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool Create(Reactie reactie)
        {
            string query;
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                query = "INSERT INTO Reactie (datum, inhoud,postID) VALUES (@datum, @inhoud, @vraagID)";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@datum", reactie.Datum);
                cmd.Parameters.AddWithValue("@inhoud", reactie.Inhoud);
                cmd.Parameters.AddWithValue("@vraagID", reactie.PostID);
                //            //cmd.Parameters.AddWithValue("@uitzendID", 1);
                //            //cmd.Parameters.AddWithValue("@accountID", 1);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            connection.Close();
            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reactie> GetAll(int postID)
        {
            List<Reactie> reactieLijst = new List<Reactie>();
            string query = "SELECT * FROM dbo.Reactie WHERE postID = 1014 ORDER BY datum DESC";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue(@"postID", postID);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reactieLijst.Add(new Reactie(
                            (int)reader["reactieID"],
                            reader["inhoud"].ToString(),
                            (DateTime)reader["datum"],
                            (int)reader["postId"]));
                    }
                }
                connection.Close();
            }
            return reactieLijst;
        }

        public Reactie GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reactie reactie)
        {
            throw new NotImplementedException();
        }
    }
}
