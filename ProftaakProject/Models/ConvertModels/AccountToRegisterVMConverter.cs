using ProftaakProject.Models.ViewModels.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ConvertModels
{
    public class AccountToRegisterVMConverter
    {
        public Account ConvertToModel(RegisterViewModel rvm)
        {
            Account acc = new Account()
            {
                Gebruikersnaam = rvm.Username,
                Wachtwoord = rvm.Password,
                Email = rvm.Email,
                Naam = rvm.Name,
                Geslacht = rvm.Gender,
                Geboortedatum = rvm.Birthday
            };
            return acc;
        }
    }
}
