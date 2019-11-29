using Microsoft.AspNetCore.Identity;
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
            throw new NotImplementedException();
        }

        public async Task<bool> Login(Account user)
        {
            var result = await signInManager.PasswordSignInAsync(user.Email, user.Wachtwoord, false, lockoutOnFailure: false);
            return result.Succeeded;
        }
    }
}
