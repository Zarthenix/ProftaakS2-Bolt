using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestEventContext : IEventContext
    {
        public bool Create(Evenement ev, int userid)
        {
            throw new NotImplementedException();
        }

        public Evenement Read(int eventId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Evenement ev)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int eventId)
        {
            throw new NotImplementedException();
        }

        public List<Evenement> GetAllByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void SignOut(int eventId, int userId)
        {
            throw new NotImplementedException();
        }

        public void SignIn(int eventId, int userId)
        {
            throw new NotImplementedException();
        }

        public List<Evenement> GetAvailableEvents(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
