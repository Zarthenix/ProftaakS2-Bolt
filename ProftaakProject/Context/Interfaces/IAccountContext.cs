using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IAccountContext
    {
        bool VoegToeUitzend(int uitzend, int accId);

        List<Account> GetAll(int id);

        Account GetByID(int id);

        bool VerwijderUitzend(int id);
    }
}
