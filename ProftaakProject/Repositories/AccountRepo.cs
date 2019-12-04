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

        public List<Account> GetAll(int id)
        {
            return ctx.GetAll(id);
        }
    }
}
