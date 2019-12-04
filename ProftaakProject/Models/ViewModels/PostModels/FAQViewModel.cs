using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels.PostModels
{
    public class FAQViewModel
    {
        public List<Post> PopulaireVragen { get; set; }
        public List<Tag> AlleTags { get; set; }
    }
}
