using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string Email { get; set; }

        public string Gebruikersnaam { get; set; }

        public int UitzendID { get; set; }
    }
}
