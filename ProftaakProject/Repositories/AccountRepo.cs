﻿using ProftaakProject.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories
{
    public class AccountRepo 
    {
        private IAuthContext authContext;
        private IAccountContext accContext;

        public AccountRepo(IAuthContext authContext, IAccountContext accountContext)
        {
            this.authContext = authContext;
            accContext = accountContext;
        }

        public Task<bool> Login(Account user)
        {
            return authContext.Login(user);
        }

        public void Logout()
        {
            authContext.Logout();
        }

        public Task<bool> Register(Account user, int rol)
        {
            return authContext.Register(user, rol);
        }

        public bool VoegToeUitzend(int uitzend, string gebruikersnaam)
        {
            return accContext.VoegToeUitzend(uitzend, gebruikersnaam);
        }

        public List<Account> GetAllUitzend(int id)
        {
            return accContext.GetAllUitzend(id);
        }

        public List<Account> GetAll()
        {
            return accContext.GetAll();
        }

        public Account GetByID(int id)
        {
            return accContext.GetByID(id);
        }

        public bool VerwijderUitzend(int id)
        {
            return accContext.VerwijderUitzend(id);
        }
    }
}
