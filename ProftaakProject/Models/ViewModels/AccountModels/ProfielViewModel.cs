using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models;

namespace ProftaakProject.Models.ViewModels
{
    public class ProfielViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vul een naam in.")]
        [DataType(DataType.Text)]
        [Display(Name = "Voornaam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Vul een email in.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vul een geldige email in.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul een geslacht in.")]
        [DataType(DataType.Text)]
        [Display(Name = "Geslacht")]
        public Gender Geslacht { get; set; }

        [Required(ErrorMessage = "Vul een geboortedatum in.")]
        [DataType(DataType.Text)]
        [Display(Name = "Geboortedatum")]
        public DateTime Geboortedatum { get; set; }

        public Account Account { get; set; }

        [Required(ErrorMessage = "Kies een rol")]
        [DataType(DataType.Text)]
        [Display(Name = "Rol")]
        public string Rol
        {
            get { return this.Rol;}
            set { this.Rol = Account.Rol.Gebruiker.ToString(); }
        }
    }
}
