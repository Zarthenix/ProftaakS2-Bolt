using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IUitzendContext
    {


        public bool Create(Uitzendbureau ub);

        public bool Update(Uitzendbureau ub);

        public bool Delete(int id);

        public List<Uitzendbureau> GetAll();

        public Uitzendbureau GetByID(int id);

        public bool VoegToeAccountUitzend(int uitzend, string gebruikersnaam);

        public List<Account> GetUitzendAccounts(int id);

        public bool VerwijderAccountUitzend(int id);

        public Uitzendbureau GetByAccountID(int id);
    }
}
