using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProftaakProject.Models.ViewModels
{
    public class UitzendViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vul een naam in.")]
        public string Naam { get; set; }

        public int Eigenaar { get; set; }

        public List<Uitzendbureau> ubs { get; set; }
    }
}
