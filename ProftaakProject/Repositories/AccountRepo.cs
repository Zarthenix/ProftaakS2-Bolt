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
        private readonly IAccountContext ctx;

        public AccountRepo(IAccountContext context)
        {
            this.ctx = context;
        }

        public bool VoegToeUitzend(int uitzend, int accId)
        {
            return ctx.VoegToeUitzend(uitzend, accId);
        }

        public List<Account> GetAll(int id)
        {
            return ctx.GetAll(id);
        }

        public Account GetByID(int id)
        {
            return ctx.GetByID(id);
        }

        public bool VerwijderUitzend(int id)
        {
            return ctx.VerwijderUitzend(id);
        }
    }
}
