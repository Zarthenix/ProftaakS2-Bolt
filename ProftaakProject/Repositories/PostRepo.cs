using ProftaakProject.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories
{
    public class PostRepo : IPostContext
    {
        private readonly IPostContext ctx;

        public PostRepo(IPostContext context)
        {
            this.ctx = context;
        }

        public Post Create(Post post)
        {
            return ctx.Create(post);
        }

        /*public Post Update(int id)
        {
            return ctx.Update(id);
        }

        public Post Delete(int id)
        {
            return ctx.Delete(id);
        }*/

        public Post GetByID(int id)
        {
            return ctx.GetByID(id);
        }

        /*public List<Post> GetAll()
        {
            return ctx.GetAll();
        }*/
    }
}
