using Microsoft.AspNetCore.Identity;
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
    public class MSSQLAuthContext : IAuthContext
    {
        private SignInManager<Account> signInManager;
        private UserManager<Account> userManager;
        private readonly string _connectionString;

        public MSSQLAuthContext(SignInManager<Account> signInManager, UserManager<Account> userManager, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> Register(Account user, int rol)
        {
            var result = await userManager.CreateAsync(user, user.Wachtwoord); 

            if (result.Succeeded)
            {
               using (var connection = new SqlConnection(_connectionString))
               {
                    SqlCommand cmd = new SqlCommand("DECLARE @id INT UPDATE dbo.[Account] SET [naam] = @naam, [geslacht] = @geslacht, [geboortedatum] = @geboortedatum, @id = [accountId] WHERE [gebruikersnaam] = @username select @id", connection);
                    cmd.Parameters.AddWithValue("@naam", user.Naam);
                    cmd.Parameters.AddWithValue("@geslacht", user.Geslacht);
                    cmd.Parameters.AddWithValue("@geboortedatum", user.Geboortedatum);
                    cmd.Parameters.AddWithValue("@username", user.Gebruikersnaam);

                    connection.Open();
                    user.Id = (int)cmd.ExecuteScalar();
                    connection.Close();

                    return SetRole(user, rol);
               }
            }
            return false;
        }

        //methode ophalen alle rollen (select * from role) id + rolnaam ophalen


        public bool SetRole(Account user, int rol)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[User_Role] (User_id, Role_Id) VALUES (@userid, @roleid)", connection);
                cmd.Parameters.AddWithValue("@userid", user.Id);
                cmd.Parameters.AddWithValue("@roleid", rol);
                connection.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows != 0 || rows != -1)
                {
                    return true;
                }
                else return false;
            }
        }

        public async Task<bool> Login(Account user)
        {
            var result = await signInManager.PasswordSignInAsync(user.Gebruikersnaam, user.Wachtwoord, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async void Logout()
        {
            await signInManager.SignOutAsync();
        }

        public bool UpdatePassword(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE dbo.Account SET wachtwoord = @wachtwoord WHERE accountID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
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

        public async Task<bool> Delete(Account user)
        {
            var result = await userManager.DeleteAsync(user);
            return true;
        }
    }
}
