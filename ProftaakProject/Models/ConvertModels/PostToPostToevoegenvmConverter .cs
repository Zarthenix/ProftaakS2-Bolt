using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels.PostModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class PostToPostToevoegenvmConverter
    {
        public Post ConvertToModel(ArtikelToevoegenViewModel ptvm)
        {
            MemoryStream memoryStream = new MemoryStream();
            ptvm.ImageFile.CopyTo(memoryStream);
            Post p = new Post();
            {
                p.Inhoud = ptvm.Inhoud;
                p.Titel = ptvm.Titel;
                p.Datum = ptvm.Datum;
                p.TypeId = ptvm.TypeId;
                p.ImageFile = memoryStream.ToArray();

            }
            return p;
        }
        public ArtikelToevoegenViewModel ConvertToViewModel(Post p)
        {
            ArtikelToevoegenViewModel ptvm = new ArtikelToevoegenViewModel();
            {
                ptvm.Inhoud = p.Inhoud;
                ptvm.Titel = p.Titel;
                ptvm.Datum = p.Datum;
                ptvm.TypeId = p.TypeId;
            }
            return ptvm;
        }
    }
}