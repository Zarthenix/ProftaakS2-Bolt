using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestAuthContext : IAuthContext
    {
        public Task<bool> Delete(Account user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(Account user)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(Account user, int rol)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(int id)
        {
            throw new NotImplementedException();
        }
    }
}
