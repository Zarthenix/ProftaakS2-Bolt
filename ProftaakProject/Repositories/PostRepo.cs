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

        public bool Create(Post post)
        {
            return ctx.Create(post);
        }

        public bool Update(Post post)
        {
            return ctx.Update(post);
        }

        //public Post Delete(int id)
        //{
        //    return ctx.Delete(id);
        //}

        public Post GetByID(int id)
        {
            return ctx.GetByID(id);
        }

        public List<Post> GetAll()
        {
            return ctx.GetAll();
        }
        public bool Check(Post post)
        {
            if (post.Id < 0)
            {
                return ctx.Create(post);
            }
            else
            {
                return ctx.Update(post);
            }
        }

    }
}
