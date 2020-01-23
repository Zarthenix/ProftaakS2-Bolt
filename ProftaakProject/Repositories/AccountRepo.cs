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

        public bool UpdatePassword(int id)
        {
            return authContext.UpdatePassword(id);
        }

        public List<Account> GetAll()
        {
            return accContext.GetAll();
        }

        public Account GetByID(int id)
        {
            return accContext.GetByID(id);
        }

        public Account GetByName(string name)
        {
            return accContext.GetByName(name);
        }

        public bool VerwijderUitzend(int id)
        {
            return accContext.VerwijderUitzend(id);
        }

        public bool Update(Account account)
        {
            return accContext.Update(account);
        }

        public List<Post> GetAllPostsOfUser(int userId)
        {
            return accContext.GetAllPostsOfUser(userId);
        }
    }
}
