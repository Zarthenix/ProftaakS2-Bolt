using ProftaakProject.Models.ViewModels.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels.AccountModels
{
    public class GeschiedenisViewModel
    {
        public List<PostViewModel> Posts { get; set; }

        public GeschiedenisViewModel()
        {
            Posts = new List<PostViewModel>();
        }
    }
}
