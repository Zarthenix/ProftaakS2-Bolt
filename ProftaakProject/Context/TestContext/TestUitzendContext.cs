using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Context.TestContext.TestData;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestUitzendContext : IUitzendContext
    {
        private List<Uitzendbureau> _bureaus = UitzendTestData.ResetData();
        public bool Create(Uitzendbureau ub)
        {
            _bureaus.Add(ub);
            if (_bureaus[_bureaus.Count - 1] == ub)
            {
                return true;
            }

            return false;
        }

        public bool Update(Uitzendbureau ub)
        {
            int index = _bureaus.IndexOf(_bureaus.FirstOrDefault(n => n.Id == ub.Id));
            if (index != -1)
            {
                _bureaus[index] = ub;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            int index = _bureaus.IndexOf(_bureaus.FirstOrDefault(n => n.Id == id));
            _bureaus.RemoveAt(index);

            if (_bureaus.IndexOf(_bureaus.FirstOrDefault(n => n.Id == id)) == -1)
            {
                return true;
            }

            return false;
        }

        public List<Uitzendbureau> GetAll()
        {
            return _bureaus;
        }

        public Uitzendbureau GetByID(int id)
        {
            return _bureaus.FirstOrDefault(n => n.Id == id);
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
