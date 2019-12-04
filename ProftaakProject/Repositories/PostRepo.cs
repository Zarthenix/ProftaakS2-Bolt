using ProftaakProject.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories
{
    public class PostRepo
    {
        private readonly IPostContext pCtx;
        private readonly ITagContext tCtx;

        public PostRepo(IPostContext postContext, ITagContext tagContext)
        {
            this.pCtx = postContext;
            this.tCtx = tagContext;
        }

        public bool Create(Post post)
        {
            return pCtx.Create(post);
        }

        public bool Update(Post post)
        {
            return pCtx.Update(post);
        }

        public bool Delete(int id)
        {
            return pCtx.Delete(id);
        }

        public Post GetByID(int id)
        {
            return pCtx.GetByID(id);
        }

        public Tag GetTagByID(int id)
        {
            return tCtx.GetTagByID(id);
        }

        public List<Post> GetAll()
        {
            return pCtx.GetAll();
        }

        public List<Tag> GetAllTags()
        {
            return tCtx.GetAll();
        }

        public bool Save(Post post)
        {
            if (post.Id <= 0)
            {
                return pCtx.Create(post);
            }
            else
            {
                return pCtx.Update(post);
            }
        }

    }
}
