using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class PostToVraagvmConverter
    {
        public Post ConvertToModel(VraagViewModel vvm)
        {
            Post p = new Post();
            {
            }
            return p;
        }

        public VraagViewModel ConvertToViewModel(Post p)
        {
            VraagViewModel vvm = new VraagViewModel();
            {
                vvm.Post = p;
            }
            return vvm;
        }
    }
}
