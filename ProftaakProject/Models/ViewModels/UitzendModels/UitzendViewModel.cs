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
        [DataType(DataType.Text)]
        public string Naam { get; set; }

        public int Eigenaar { get; set; }

        public List<Uitzendbureau> ubs { get; set; }

        public List<Account> avm { get; set; }
        public Account AccountTeVerwijderen { get; set; }
    }
}
