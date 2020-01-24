using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Context.TestContext.TestData;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestEventContext : IEventContext
    {
        private List<Evenement> events = EventTestData.ResetData();

        public bool Create(Evenement ev, int userid)
        {
            ev.Host = new Account(userid);
            events.Add(ev);
            if (events[events.Count - 1] == ev)
            {
                return true;
            }

            return false;
        }

        public Evenement Read(int eventId)
        {
            var evenement = events.FirstOrDefault(n => n.Id == eventId);

            if (evenement != null)
            {
                return evenement;
            }
            return new Evenement(-1);
        }

        public bool Update(Evenement ev)
        {
            int index = events.IndexOf(events.FirstOrDefault(n => n.Id == ev.Id));
            if (index != -1)
            {
                events[index] = ev;
                return true;
            }
            return false;
        }

        public bool Delete(int eventId)
        {
            int index = events.IndexOf(events.FirstOrDefault(n => n.Id == eventId));
            events.RemoveAt(index);

            if (events.IndexOf(events.FirstOrDefault(n => n.Id == eventId)) == -1)
            {
                return true;
            }

            return false;
        }

        public List<Evenement> GetAllByUserId(int userId)
        {
            return events.Where(n => n.Host.Id == userId).ToList();
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
