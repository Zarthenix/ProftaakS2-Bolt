using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IAccountContext
    {
        List<Account> GetAll();

        Account GetByID(int id);

        Account GetByName(string name);

        bool VerwijderUitzend(int id);

        bool Update(Account account);
    }
}
