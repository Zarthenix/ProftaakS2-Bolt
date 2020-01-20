using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data;

namespace ProftaakProject.Context.SQLContext
{
    public class MSSQLEventContext : IEventContext
    {
        private readonly string _connectionString;

        public MSSQLEventContext(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public bool Create(Evenement evenement, int userId)
        {
            bool result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("EXEC dbo.[CreateEvent] @Naam = @name, @Datum = @date, @Host = @owner, @Locatie = @location, @MaxDeelnemers = @maxPart", connection)
                {
                    Parameters =
                    {
                        new SqlParameter("@name", evenement.Naam),
                        new SqlParameter("@date", evenement.Datum),
                        new SqlParameter("@owner", userId),
                        new SqlParameter("@location", evenement.Locatie),
                        new SqlParameter("@maxPart", evenement.MaxDeelnemers)
                    }
                };

                try
                {
                    connection.Open();
                    if (cmd.ExecuteNonQuery() != -1)
                    {
                        result = true;
                    }
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        public Evenement Read(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [naam], [datum], [host], [locatie], [maxDeelnemers] FROM dbo.[Evenement] WHERE[evtId] = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Evenement evenement = new Evenement
                    {
                        Id = id
                    };
                    while (reader.Read())
                    {
                        evenement.Naam = reader["naam"].ToString();
                        evenement.Datum = (DateTime)reader["datum"];
                        evenement.Host = (int)reader["host"];
                        evenement.Locatie = reader["locatie"].ToString();
                        evenement.MaxDeelnemers = (int)reader["maxDeelnemers"];
                    }
                    return evenement;
                }
            }
            return default;
        }

        public bool Update(Evenement ev)
        {
            bool result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("EXEC dbo.[UpdateEvenement] @naam = @name, @datum = @date, @host = @owner, @locatie = @location, @maxdeelnemers = @maxPart, @id = @evid", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Parameters =
                    {
                        new SqlParameter("@name", ev.Naam),
                        new SqlParameter("@date", ev.Datum),
                        new SqlParameter("@owner", ev.Host),
                        new SqlParameter("@location", ev.Locatie),
                        new SqlParameter("@maxPart", ev.MaxDeelnemers),
                        new SqlParameter("@evid", ev.Id)
                    }
                };
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected != -1) result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.[Evenement] WHERE [evtId] = @id");
                cmd.Parameters.AddWithValue("@id", id);
                
                
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected != -1) result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        public List<Evenement> GetAllByUserId(int userId)
        {
            List<Evenement> evenementen = new List<Evenement>();
            DataSet ds = new DataSet();

            using var connection = new SqlConnection(_connectionString);

            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [GetEventsByUser] (@userid)", connection))
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@userid", userId);

                using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                connection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Evenement evenement = new Evenement()
                {
                    Id = (int)dr["evtID"],
                    Naam = dr["naam"].ToString(),
                    Datum = (DateTime)dr["datum"],
                    Host = (int)dr["host"],
                    Locatie = dr["locatie"].ToString(),
                    MaxDeelnemers = (int)dr["maxDeelnemers"]
                };
                evenementen.Add(evenement);
            }
            return evenementen;
        }

    }
}