using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels.AccountModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Gebruikersnaam is verplicht.")]
        [DataType(DataType.Text)]
        [Display(Name = "Gebruikersnaam")]
        [StringLength(50, ErrorMessage = "Maximaal aantal karakters is 50.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "E-mail is verplicht.")]
        [Display(Name = "E-mail")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is ongeldig.")]
        [StringLength(100, ErrorMessage = "Maximaal aantal karakters is 100.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,15}$", ErrorMessage = "Minimum of 6 characters and maximum of 15. Must contain 1 uppercase and lowercase letter, 1 digit and 1 special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Wachtwoord bevestigen is verplicht.")]
        [DataType(DataType.Password)]
        [Display(Name = "Bevestig uw wachtwoord")]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Uw volledige naam invullen is verplicht.")]
        [DataType(DataType.Text)]
        [Display(Name = "Volledige naam")]
        [StringLength(50, ErrorMessage = "Maximaal 50 karakters.")]
        public string Name { get; set; }

        [Display(Name = "Geslacht")]
        public int Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime Birthday { get; set; }

        public List<string> Genders
        {
            get
            {
                return Enum.GetValues(typeof (ProftaakProject.Models.Gender))
                    .Cast<Gender>()
                    .Select(v => v.ToString())
                    .ToList();
            }
        }
    }
}
