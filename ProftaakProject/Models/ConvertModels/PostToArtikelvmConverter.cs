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
            }
            return p;
        }

        public ArtikelViewModel ConvertToViewModel(Post p)
        {
            ArtikelViewModel avm = new ArtikelViewModel();
            {
            }
            return avm;
        }
    }
}
