using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models;

namespace ProftaakProject.Models.ViewModels
{
    public class ProfielViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Geslacht { get; set; }
        public DateTime Geboortedatum { get; set; }

        public string Rol
        {
            get { return this.Rol;}
            set { this.Rol = Account.Rol.Gebruiker.ToString(); }
        }
        public int BerekenLeeftijd(DateTime dateTime)
        {
            return 0;
        }
    }
}
