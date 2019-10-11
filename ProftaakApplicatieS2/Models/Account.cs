using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakApplicatieS2.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Geslacht { get; set; }
        public DateTime Geboortedatum { get; set; }
        public enum Rol
        {

        }
        public int berekenLeeftijd(DateTime dateTime)
        {
            return 0;
        }
        public Account()
        {

        }
    }
}
