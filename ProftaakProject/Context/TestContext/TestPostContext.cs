using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestPostContext : IPostContext
    {
        public bool Create(Post post)
        {
            throw new NotImplementedException();
        }

        public bool Update(Post post)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Post GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllArtikelen()
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllVragenByID(int AccountId)
        {
            throw new NotImplementedException();
        }

        public List<Post> FAQVragenByTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public bool IncrementViews(int postID)
        {
            throw new NotImplementedException();
        }

        public List<Post> SearchResult(string search, int userid)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllArtikelenGoedkeuren()
        {
            throw new NotImplementedException();
        }

        public bool UpdateGoedgekeurd(int accId, int postId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPostsByTagId(int tagId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllArtikelenByAantalBekeken()
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }
    }
}
