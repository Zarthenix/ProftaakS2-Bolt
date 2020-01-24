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

        public List<Post> GetAllArtikelen()
        {
            return pCtx.GetAllArtikelen();
        }
        public List<Post> GetAllVragenByID(int AccountId)
        {
            return pCtx.GetAllVragenByID(AccountId);
        }

        public List<Tag> GetAllTags()
        {
            return tCtx.GetAll();
        }

        public List<Tag> GetAllByUserID(int id)
        {
            return tCtx.GetAllByUserID(id);
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

        public bool IncrementViews(int postID)
        {
            return pCtx.IncrementViews(postID);
        }

        public List<Post> FAQVragenByTag(Tag tag)
        {
            return pCtx.FAQVragenByTag(tag);
        }

        public List<Post> SearchResult(string search, int userid)
        {
            return pCtx.SearchResult(search, userid);
        }

        public List<Post> GetAllArtikelenGoedkeuren()
        {
            return pCtx.GetAllArtikelenGoedkeuren();
        }

        public bool UpdateGoedgekeurd(int accId, int postId)
        {
            return pCtx.UpdateGoedgekeurd(accId, postId);
        }

        public List<Post> GetAllPostsByTagId(int tagId)
        {
            return pCtx.GetAllPostsByTagId(tagId);
        }
        public bool AbonnerenOpTag(int tagId, int accId)
        {
            return tCtx.AbonnerenOpTag(tagId, accId);
        }
        public bool AbonnerenTagOpzeggen(int tagId, int accId)
        {
            return tCtx.AbonnerenTagOpzeggen(tagId, accId);
        }
        public bool IsGeabonneerdOpTag(int tagId, int accId)
        {
            return tCtx.IsGeabonneerdOpTag(tagId, accId);
        }
        public List<Tag> GetAllGeabonneerdeTags(int accId)
        {
            return tCtx.GetAllGeabonneerdeTags(accId);
        }

        public List<Post> GetAllArtikelenByAantalBekeken()
        {
            return pCtx.GetAllArtikelenByAantalBekeken();
        }
        public List<Post> GetAllPosts()
        {
            return pCtx.GetAllPosts();
        }
    }
}
