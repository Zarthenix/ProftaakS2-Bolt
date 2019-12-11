﻿using ProftaakProject.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories
{
    public class ReactieRepo
    {
        private readonly IReactieContext rCtx;

        public ReactieRepo(IReactieContext reactieContext)
        {
            this.rCtx = reactieContext;
        }

        public bool Create(Reactie reactie)
        {
            return rCtx.Create(reactie);
        }

        public bool Update(Reactie reactie)
        {
            return rCtx.Update(reactie);
        }

        public bool Delete(int id)
        {
            return rCtx.Delete(id);
        }

        public Reactie GetByID(int id)
        {
            return rCtx.GetByID(id);
        }

        public List<Reactie> GetAll()
        {
            return rCtx.GetAll();
        }
    }
}
