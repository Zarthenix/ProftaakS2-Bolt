using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IAccountContext
    {
        List<Account> GetAll(int id);

        public Account GetByID(int id);
    }
}
