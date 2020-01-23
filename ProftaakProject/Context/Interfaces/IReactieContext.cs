using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IReactieContext
    {
        bool Create(Reactie reactie);

        bool Update(Reactie reactie);

        bool Delete(int id);

        Reactie GetByID(int id);

        List<Reactie> GetAll(int postID);

        bool ReactieGelezen(int reactieID);

        bool ReactieGoedkeuren(int reactieID, int accountID, bool goedgekeurd);
    }
}
