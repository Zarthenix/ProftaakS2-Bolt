using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels.Post;

namespace ProftaakProject.Models.ConvertModels
{
    public class PostToPostvmConverter
    {
        public Post ConvertToModel(PostViewModel pvm)
        {
            Post p = new Post();
            {
                p.Inhoud = pvm.Inhoud;
                p.Titel = pvm.Titel;
                p.Datum = pvm.Datum;
            }
            return p;
        }
        public PostViewModel ConvertToViewModel(Post p)
        {
            PostViewModel pvm = new PostViewModel();
            {
                pvm.Inhoud = p.Inhoud;
                pvm.Titel = p.Titel;
                pvm.Datum = p.Datum;
            }
            return pvm;
        }
    }
}
