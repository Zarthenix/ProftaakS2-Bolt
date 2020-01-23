using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Data.SqlClient;
using ProftaakProject.Models;

namespace ProftaakProject
{
    public class MSSQLUserContext : IUserStore<Account>, IUserPasswordStore<Account>, IUserEmailStore<Account>, IUserRoleStore<Account>
    {
        private readonly string _connectionString;
        public MSSQLUserContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Create a user in de DB. The Id (in de database) must be set to auto increment. 
        /// The Wachtwoord is hashed automatically.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO [Account] (gebruikersnaam, emailadres, wachtwoord) VALUES (@gebruikersnaam, @emailadres, @wachtwoord)", connection);
                    sqlCommand.Parameters.AddWithValue("@gebruikersnaam", user.Gebruikersnaam);
                    sqlCommand.Parameters.AddWithValue("@wachtwoord", user.Wachtwoord);
                    sqlCommand.Parameters.AddWithValue("@emailadres", user.Email);
                    user.Id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    if (user.Id == -1)
                    {
                        throw new Exception("Database error.");
                    }

                    connection.Close();
                    return Task.FromResult<IdentityResult>(IdentityResult.Success);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        /// <summary>
        ///Delete the user from the database (or make the user obsolete)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("DELETE FROM Account WHERE accountID = @accountID", connection);
                    sqlCommand.Parameters.AddWithValue("@accountID", user.Id);
                    sqlCommand.ExecuteNonQuery();

                    connection.Close();
                    return Task.FromResult<IdentityResult>(IdentityResult.Success);
                }
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //nothing to do.
        }


        /// <summary>
        /// Finding a user by Email in the database
        /// </summary>
        /// <param name="normalizedEmail"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Account> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT accountID, gebruikersnaam, emailadres FROM [Account] WHERE emailadres=@email", connection);
                sqlCommand.Parameters.AddWithValue("@email", normalizedEmail);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    Account user = default(Account);
                    if (sqlDataReader.Read())
                    {
                        user = new Account(Convert.ToInt32(sqlDataReader["accountID"].ToString()), sqlDataReader["gebruikersnaam"].ToString(), sqlDataReader["emailadres"].ToString());

                    }
                    connection.Close();
                    return Task.FromResult(user);
                }
            }
        }

        /// <summary>
        /// Finding a user by id in the datbase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Account> FindByIdAsync(string id, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT accountID, gebruikersnaam, emailadres FROM [Account] WHERE accountID=@id", connection);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        Account user = default(Account);
                        if (sqlDataReader.Read())
                        {
                            user = new Account(Convert.ToInt32(sqlDataReader["accountID"].ToString()), sqlDataReader["gebruikersnaam"].ToString(), sqlDataReader["emailadres"].ToString());

                        }
                        connection.Close();
                        return Task.FromResult(user);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Account> FindByNameAsync(string normalizedGebruikersnaam, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT accountID, gebruikersnaam, emailadres, wachtwoord FROM [Account] WHERE gebruikersnaam=@gebruikersnaam", connection);
                    sqlCommand.Parameters.AddWithValue("@gebruikersnaam", normalizedGebruikersnaam);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        Account user = default(Account);
                        if (sqlDataReader.Read())
                        {
                            user = new Account(Convert.ToInt32(sqlDataReader["accountID"].ToString()), sqlDataReader["gebruikersnaam"].ToString(), sqlDataReader["emailadres"].ToString(), sqlDataReader["wachtwoord"].ToString());
                        }
                        connection.Close();
                        return Task.FromResult(user);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<string> GetEmailAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedGebruikersnaam);
        }

        public Task<string> GetPasswordHashAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Wachtwoord);
        }

        public Task<IList<string>> GetRolesAsync(Account user, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT r.[Name] FROM [Role] r INNER JOIN [User_Role] ur ON ur.[Role_Id] = r.Id WHERE ur.User_Id = @Id", connection);
                    sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        IList<string> roles = new List<string>();
                        while (sqlDataReader.Read())
                        {
                            roles.Add(sqlDataReader["Name"].ToString());
                        }
                        connection.Close();
                        return Task.FromResult(roles);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Gebruikersnaam);
        }

        public Task<IList<Account>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Wachtwoord != null);
        }

        public Task<bool> IsInRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            try
            {

                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand sqlCommandUserRole = new SqlCommand("SELECT COUNT(*) FROM [User_Role] WHERE [User_Id] = @Id AND (SELECT [Name] from [Role] WHERE [Id] = @Id) = @RoleName)", connection);
                    sqlCommandUserRole.Parameters.AddWithValue("@Id", user.Id);
                    sqlCommandUserRole.Parameters.AddWithValue("@RoleName", roleName);

                    int? roleCount = sqlCommandUserRole.ExecuteScalar() as int?;
                    connection.Close();
                    return Task.FromResult(roleCount > 0);

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task RemoveFromRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(Account user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(Account user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(Account user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedGebruikersnaam = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(Account user, string wachtwoordHash, CancellationToken cancellationToken)
        {
            user.Wachtwoord = wachtwoordHash;
            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(Account user, string gebruikersnaam, CancellationToken cancellationToken)
        {
            user.Gebruikersnaam = gebruikersnaam;
            return Task.FromResult(0);
        }
        /// <summary>
        /// Update user in database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
