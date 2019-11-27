using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels.PostModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class PostToPostvmConverter
    {
        public Post ConvertToModel(PostViewModel pvm)
        {
            MemoryStream memoryStream = new MemoryStream();
            pvm.ImageFile.CopyTo(memoryStream);
            Post p = new Post();
            {
                p.Inhoud = pvm.Inhoud;
                p.Titel = pvm.Titel;
                p.Datum = pvm.Datum;
                p.TypeId = pvm.TypeId;
                p.ImageFile = memoryStream.ToArray();

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
                pvm.TypeId = p.TypeId;
            }
            return pvm;
        }
    }
}
