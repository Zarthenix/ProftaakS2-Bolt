using ProftaakProject.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories
{
    public class AccountRepo 
    {
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
