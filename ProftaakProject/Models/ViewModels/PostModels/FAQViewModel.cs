using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels.PostModels
{
    public class FAQViewModel
    {
        public List<List<Post>> PopulaireVragen { get; set; }

        public FAQViewModel()
        {
            this.PopulaireVragen = new List<List<Post>>();
        }
    }
}
