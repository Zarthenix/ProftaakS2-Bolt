using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestUitzendContext : IUitzendContext
    {
        public bool Create(Uitzendbureau ub)
        {
            throw new NotImplementedException();
        }

        public bool Update(Uitzendbureau ub)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Uitzendbureau> GetAll()
        {
            throw new NotImplementedException();
        }

        public Uitzendbureau GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool VoegToeAccountUitzend(int uitzend, string gebruikersnaam)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetUitzendAccounts(int id)
        {
            throw new NotImplementedException();
        }

        public bool VerwijderAccountUitzend(int id)
        {
            throw new NotImplementedException();
        }

        public Uitzendbureau GetByAccountID(int id)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfAccountInUitzend(int accountID)
        {
            throw new NotImplementedException();
        }
    }
}
