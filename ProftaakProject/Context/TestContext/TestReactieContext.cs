using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestReactieContext : IReactieContext

    {
        public bool Create(Reactie reactie)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reactie reactie)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Reactie GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reactie> GetAll(int postID)
        {
            throw new NotImplementedException();
        }

        public bool ReactieGelezen(int reactieID)
        {
            throw new NotImplementedException();
        }

        public bool ReactieGoedkeuren(int reactieID, int accountID)
        {
            throw new NotImplementedException();
        }

        public bool ReactieGoedkeuren(int reactieID, int accountID, bool goedgekeurd)
        {
            throw new NotImplementedException();
        }
    }
}
