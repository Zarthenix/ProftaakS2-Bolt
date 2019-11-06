using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Gebruikersnaam { get; set; }
        public string NormalizedGebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Geslacht { get; set; }
        public DateTime Geboortedatum { get; set; }
        public Role rol { get; set; }
        public int BerekenLeeftijd(DateTime dateTime)
        {
            return 0;
        }
        public Account()
        {

        }
    }
}
