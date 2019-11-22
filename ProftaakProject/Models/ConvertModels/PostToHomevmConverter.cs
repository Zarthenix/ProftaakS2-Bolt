using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class PostToHomevmConverter
    {
        public HomeViewModel PostToHomevm(List<Post> listPost)
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Posts = listPost;
            return hvm;
        }
    }
}
