using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels.PostModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class PostToArtikelToevoegenvmConverter
    {
        public Post ConvertToModel(ArtikelToevoegenViewModel atvm)
        {
            MemoryStream memoryStream = new MemoryStream();
            atvm.ImageFile.CopyTo(memoryStream);
            Post p = new Post();
            {
                p.Id = atvm.Id;
                p.Inhoud = atvm.Inhoud;
                p.Titel = atvm.Titel;
                p.Datum = atvm.Datum;
                p.TypeId = atvm.TypeId;
                p.Tag = atvm.Tag;
                p.ImageFile = memoryStream.ToArray();
                p.Uitzendbureau = atvm.Uitzendbureau;
            }
            return p;
        }
        public ArtikelToevoegenViewModel ConvertToViewModel(Post p)
        {
            ArtikelToevoegenViewModel atvm = new ArtikelToevoegenViewModel();
            {
                atvm.Id = p.Id;
                atvm.Inhoud = p.Inhoud;
                atvm.Titel = p.Titel;
                atvm.Datum = p.Datum;
                atvm.TypeId = p.TypeId;
                atvm.Uitzendbureau = p.Uitzendbureau;
            }
            return atvm;
        }
    }
}