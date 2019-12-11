using ProftaakProject.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories
{
    public class AccountRepo 
    {
        private IAuthContext authContext;
        private IAccountContext accContext;

        public AccountRepo(IAuthContext authContext, IAccountContext accountContext)
        {
            this.authContext = authContext;
            accContext = accountContext;
        }

        public Task<bool> Login(Account user)
        {
            return authContext.Login(user);
        }

        public void Logout()
        {
            authContext.Logout();
        }

        public Task<bool> Register(Account user, int rol)
        {
            return authContext.Register(user, rol);
        }

        public bool VoegToeUitzend(int uitzend, int accId)
        {
            return accContext.VoegToeUitzend(uitzend, accId);
        }

        public List<Account> GetAll(int id)
        {
            return accContext.GetAll(id);
        }

        public Account GetByID(int id)
        {
            return accContext.GetByID(id);
        }

        public bool VerwijderUitzend(int id)
        {
            return accContext.VerwijderUitzend(id);
        }
    }
}
