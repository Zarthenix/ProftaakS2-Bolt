using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels
{
    public class VraagViewModel
    {
        public Post Post { get; set; }
        [Required(ErrorMessage = "Vul eerst een reactie in.")]
        [StringLength(150, ErrorMessage = "Uw reactie voldoet niet aan de eisen. Minimum: 10, Maximum: 150", MinimumLength = 10)]
        public string ReactieInhoud { get; set; }
        public Reactie ReactieAanmaken { get; set; }
        public List<Reactie> Reacties { get; set; }
    }
}
