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
    public class MSSQLAccountContext : IAccountContext
    {
        private readonly string _connectionString;

        public MSSQLAccountContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool VoegToeUitzend(int uitzend, string gebruikersnaam)
        {
            string query = "Update Account Set uitzendID = @uitzendID where gebruikersnaam = @gebruikersnaam";
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@uitzendID", uitzend);
                        cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
                        //cmd.ExecuteNonQuery();
                        cmd.ExecuteScalar();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<Account> GetAllUitzend(int id)
        {
            List<Account> accs = new List<Account>();
            string query = "SELECT * FROM dbo.Account where uitzendID = @uitzendID";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@uitzendID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accs.Add(new Account((int)reader["accountId"], reader["naam"].ToString(), reader["emailadres"].ToString(), reader["gebruikersnaam"].ToString()));
                        }
                    }
                }

                connection.Close();
            }

            return accs;
        }

        public List<Account> GetAll()
        {
            List<Account> accs = new List<Account>();
            string query = "SELECT * FROM dbo.Account";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accs.Add(new Account((int)reader["accountId"], reader["gebruikersnaam"].ToString(), reader["emailadres"].ToString(), reader["naam"].ToString()));
                        }
                    }
                }

                connection.Close();
            }

            return accs;
        }

        public Account GetByID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT gebruikersnaam, wachtwoord, emailadres, naam, geslacht, geboortedatum, role.Name AS RoleName, role.Id AS RoleId ,uitzendID From Account Join User_Role on User_Role.User_Id = Account.accountID join Role on User_Role.Role_Id = Role.Id Where accountID = @accountID", connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@accountID", id);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Account ac = new Account(id);
                            while (reader.Read())
                            {
                                ac.Naam = reader["naam"].ToString();
                                ac.Email = reader["emailadres"].ToString();
                                ac.Gebruikersnaam = reader["gebruikersnaam"].ToString();
                                ac.Geslacht = (Gender)reader["geslacht"];
                                ac.Geboortedatum = (DateTime)reader["geboortedatum"];
                                Role role = new Role();
                                role.Id = Convert.ToInt32(reader["RoleId"]);
                                role.Naam = reader["RoleName"].ToString();
                                ac.Rol = role;
                                if (reader["uitzendID"].ToString() != "")
                                {
                                    ac.UitzendID = (int)reader["uitzendID"];
                                }
                            }
                            return ac;
                        }
                        else
                        {
                            return new Account(-1);
                        }
                    }
                }
            }
        }

        public Account GetByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dbo.Account WHERE gebruikersnaam = @gebruikersnaam ", connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@gebruikersnaam", name);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Account ac = new Account(name);
                            while (reader.Read())
                            {
                                ac.Id = (int)reader["accountID"];
                                ac.Gebruikersnaam = reader["gebruikersnaam"].ToString();
                                ac.Email = reader["emailadres"].ToString();
                                ac.Geslacht = (Gender)reader["geslacht"];
                                ac.Geboortedatum = (DateTime)reader["geboortedatum"];

                            }
                            return ac;
                        }
                        else
                        {
                            return new Account(-1);
                        }
                    }
                }
            }
        }

        public bool VerwijderUitzend(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "Update Account Set uitzendID = NULL Where accountID = @accountID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@accountID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool Update(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE dbo.Account SET naam = @naam , emailadres = @emailadres ,geslacht = @geslacht, geboortedatum = @geboortedatum WHERE accountID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", account.Id);
                        cmd.Parameters.AddWithValue("@naam", account.Naam);
                        cmd.Parameters.AddWithValue("@emailadres", account.Email);
                        cmd.Parameters.AddWithValue("@geslacht", account.Geslacht);
                        cmd.Parameters.AddWithValue("@geboortedatum", account.Geboortedatum);
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
