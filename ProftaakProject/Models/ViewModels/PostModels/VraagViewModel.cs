using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels
{
    public class VraagViewModel
    {
        public Post Post { get; set; }
        public Reactie ReactieAanmaken { get; set; }
        public List<Reactie> Reacties { get; set; }
    }
}
