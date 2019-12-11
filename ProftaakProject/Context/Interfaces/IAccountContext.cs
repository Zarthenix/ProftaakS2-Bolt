using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IAccountContext
    {
        bool VoegToeUitzend(int uitzend, string gebruikersnaam);

        List<Account> GetAllUitzend(int id);

        List<Account> GetAll();

        Account GetByID(int id);

        bool VerwijderUitzend(int id);
    }
}
