using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestAccountContext : IAccountContext
    {
        
        public List<Account> GetAll()
        {

            throw new NotImplementedException();
        }

        public Account GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetByName(string name)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
