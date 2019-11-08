using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Naam is verplicht.")]
        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        [StringLength(50, ErrorMessage = "Maximale lengte is 50 karakters.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Email is vereist.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Emailadres")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [StringLength(100, ErrorMessage = "Maximale lengte is 100 karakters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gebruikersnaam is verplicht.")]
        [DataType(DataType.Text)]
        [Display(Name = "Gebruikersnaam")]
        [StringLength(50, ErrorMessage = "Maximale lengte is 50 karakters.")]
        public string Gebruikersnaam { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        [StringLength(50, ErrorMessage = "Maximale lengte is 50 karakters.")]
        public string Wachtwoord { get; set; }

        [Required]
        [Compare("Wachtwoord", ErrorMessage = "Wachtwoorden zijn niet overeenkomend. Probeer opnieuw.")]
        [DataType(DataType.Password)]
        [Display(Name = "Bevestig wachtwoord.")]
        public string ConfirmWachtwoord { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Geslacht")]
        public string Geslacht { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime Geboortedatum { get; set; }
    }
}
