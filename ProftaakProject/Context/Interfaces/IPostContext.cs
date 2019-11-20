using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IPostContext
    {
        Post Create(Post post);

        /*Post Update(int id);

        Post Delete(int id);*/

        Post GetByID(int id);

        /*List<Post> GetAll();*/
    }
}
