using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IEventContext
    {
        bool Create(Evenement ev, int userid);
        Evenement Read(int eventId);
        bool Update(Evenement ev);
        bool Delete(int eventId);
        List<Evenement> GetAllByUserId(int userId);

    }
}
