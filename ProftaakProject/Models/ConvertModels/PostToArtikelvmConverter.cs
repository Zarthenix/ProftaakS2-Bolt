using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class PostToArtikelvmConverter
    {
        public Post ConvertToModel(ArtikelViewModel avm)
        {
            Post p = new Post();
            {
                p.Id = avm.Id;
                p.Titel = avm.Titel;
                p.Inhoud = avm.Inhoud;
            }
            return p;
        }

        public ArtikelViewModel ConvertToViewModel(Post p)
        {
            ArtikelViewModel avm = new ArtikelViewModel();
            {
                avm.Id = p.Id;
                avm.Titel = p.Titel;
                avm.Inhoud = avm.Inhoud;
            }
            return avm;
        }
    }
}
