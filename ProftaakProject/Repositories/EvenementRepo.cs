﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Repositories
{
    public class EvenementRepo
    {
        private readonly IEventContext _context;
        public EvenementRepo(IEventContext context)
        {
            _context = context;
        }

        public bool Create(Evenement ev, int userid)
        {
            return _context.Create(ev, userid);
        }

        public Evenement Read(int eventId)
        {
            return _context.Read(eventId);
        }

        public bool Update(Evenement ev)
        {
            return _context.Update(ev);
        }

        public bool Delete(int eventId)
        {
            return _context.Delete(eventId);
        }

        public void SignOut(int eventId, int userId)
        {
            _context.SignOut(eventId, userId);
        }

        public void SignIn(int eventId, int userId)
        {
            _context.SignIn(eventId, userId);
        }

        public List<Evenement> GetAvailableEvents(int userid)
        {
            return _context.GetAvailableEvents(userid);
        }

        public List<Evenement> GetAllByUserId(int userid)
        {
            return _context.GetAllByUserId(userid);
        }
    }
}
