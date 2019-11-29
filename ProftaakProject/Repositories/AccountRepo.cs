using ProftaakProject.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories
{
    public class AccountRepo
    {
        private IAuthContext context;

        public AccountRepo(IAuthContext context)
        {
            this.context = context;
        }

        public Task<bool> Login(Account user)
        {
            return context.Login(user);
        }

        public Task<bool> Register(Account user, int rol)
        {
            return context.Register(user, rol);
        }
    }
}
