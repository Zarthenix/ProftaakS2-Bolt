using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels.AccountModels
{
    public class LoginViewModel
    {   
        [Required(ErrorMessage = "Gebruikersnaam is een vereiste.")]
        [Display(Name = "Gebruikersnaam")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Maximaal aantal karakters is 50.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Wachtwoord is een vereiste.")]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Maximaal aantal karakters is 50.")]
        public string Password { get; set; }
    }
}
