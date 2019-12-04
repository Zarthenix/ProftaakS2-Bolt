using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models
{
    public enum Gender { Man, Vrouw, Anders };
    public class Account
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Gebruikersnaam { get; set; }
        public string NormalizedGebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public Gender Geslacht { get; set; }
        public DateTime Geboortedatum { get; set; }
        public enum Rol
        {
            Administrator,
            Moderator, 
            Service,
            Gebruiker,
            Gast
        }
        public int BerekenLeeftijd(DateTime dateTime)
        {
            return 0;
        }
        public Account()
        {

        }

        public Account(int id, string username, string email, string wachtwoord)
        {
            this.Id = id;
            this.Gebruikersnaam = username;
            this.Email = email;
            this.Wachtwoord = wachtwoord;
        }

        public Account(int id, string username, string email)
        {
            this.Id = id;
            this.Gebruikersnaam = username;
            this.Email = email;
        }
    }
}
