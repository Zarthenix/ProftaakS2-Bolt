using ProftaakProject.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories
{
    public class UitzendRepo : IUitzendContext
    {
        private readonly IUitzendContext ctx;

        public UitzendRepo(IUitzendContext context)
        {
            this.ctx = context;
        }

        public bool Create(Uitzendbureau ub)
        {
            return ctx.Create(ub);
        }

        public bool Check(Uitzendbureau u)
        {
            if(u.Id < 0)
            {
                return ctx.Create(u);
            }
            else
            {
                return ctx.Update(u);
            }
        }

        public bool Update(Uitzendbureau ub)
        {
            return ctx.Update(ub);
        }

        public bool Delete(int id)
        {
            return ctx.Delete(id);
        }

        public List<Uitzendbureau> GetAll()
        {
            return ctx.GetAll();
        }

        public Uitzendbureau GetByID(int id)
        {
            return ctx.GetByID(id);
        }
    }
}
