using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Context.TestContext.TestData;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestAccountContext : IAccountContext
    {
        public List<Account> GetAll()
        {
            return AccountTestData.ResetData();
        }

        public Account GetByID(int id)
        {
            return AccountTestData.ResetData().FirstOrDefault(x => x.Id == id);
        }

        public Account GetByName(string name)
        {
            return AccountTestData.ResetData().FirstOrDefault(x => x.Naam == name);
        }

        public bool VerwijderUitzend(int id)
        {

            throw new NotImplementedException();
        }

        public bool Update(Account account)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPostsOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var Accounts = AccountTestData.ResetData();
            var itemToRemove = Accounts.Single(x => x.Id == id);
            if (Accounts.Remove(itemToRemove))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Account GetByEmail(string email)
        {
            return AccountTestData.ResetData().FirstOrDefault(x => x.Email == email);
        }
    }
}
