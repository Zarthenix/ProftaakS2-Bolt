using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels.PostModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class PostToVraagToevoegenvmConverter
    {
        public Post ConvertToModel(VraagToevoegenViewModel vtvm)
        {
            Post p = new Post();
            {
                p.Id = vtvm.Id;
                p.Inhoud = vtvm.Inhoud;
                p.Titel = vtvm.Titel;
                p.Datum = vtvm.Datum;
                p.Tag = vtvm.Tag;
                p.TypeId = vtvm.TypeId;
            }
            return p;
        }
        public VraagToevoegenViewModel ConvertToViewModel(Post p)
        {
            VraagToevoegenViewModel vtvm = new VraagToevoegenViewModel();
            {
                vtvm.Id = p.Id;
                vtvm.Inhoud = p.Inhoud;
                vtvm.Titel = p.Titel;
                vtvm.Datum = p.Datum;
                vtvm.TypeId = p.TypeId;
            }
            return vtvm;
        }
    }
}