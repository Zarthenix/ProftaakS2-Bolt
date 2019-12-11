using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IPostContext
    {
        bool Create(Post post);

        bool Update(Post post);

        bool Delete(int id);

        Post GetByID(int id);

        List<Post> GetAllArtikelen();

        List<Post> FAQVragenByTag(Tag tag);

        bool IncrementViews(int postID);
    }
}
