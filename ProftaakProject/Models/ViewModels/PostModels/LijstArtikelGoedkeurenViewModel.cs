using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels.PostModels
{
    public class LijstArtikelGoedkeurenViewModel
    {
        public List<Post> Posts { get; set; }

        public LijstArtikelGoedkeurenViewModel()
        {
            this.Posts = new List<Post>();
        }
    }
}
