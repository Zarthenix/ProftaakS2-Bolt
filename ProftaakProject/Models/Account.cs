using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models
{
    public enum Rol
    {
        Administrator,
        Moderator,
        Service,
        Gebruiker,
        Gast
    }
    public enum Gender { Man, Vrouw, Anders };
    public class Account
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Gebruikersnaam { get; set; }
        public string NormalizedGebruikersnaam { get; set; }
        public List<Tag> GeabonneerdeTags { get; set; }
        public string Wachtwoord { get; set; }
        public Gender Geslacht { get; set; }
        public Rol Rol { get; set; }
        public DateTime Geboortedatum { get; set; }

        public Account(int id, string username, string email, string naam, string wachtwoord)
        {
            this.Id = id;
            this.Gebruikersnaam = username;
            this.Email = email;
            this.Naam = naam;
            List<Tag> GeabonneerdeTags = new List<Tag>();
        }

        public Account()
        {
            List<Tag> GeabonneerdeTags = new List<Tag>();
        }

        public Account(int id, string username, string email, string wachtwoord)
        {
            this.Id = id;
            this.Gebruikersnaam = username;
            this.Email = email;
            this.Wachtwoord = wachtwoord;
            List<Tag> GeabonneerdeTags = new List<Tag>();
        }

        public Account(int id, string username, string email)
        {
            this.Id = id;
            this.Gebruikersnaam = username;
            this.Email = email;
            List<Tag> GeabonneerdeTags = new List<Tag>();
        }
    }
}
