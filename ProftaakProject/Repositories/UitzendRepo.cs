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

        /*public bool Update()
        {
            return ctx.Update();
        }

        public bool Delete()
        {
            return ctx.Delete();
        }*/

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
