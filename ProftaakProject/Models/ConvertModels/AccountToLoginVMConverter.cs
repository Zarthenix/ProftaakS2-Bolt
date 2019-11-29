using ProftaakProject.Models.ViewModels.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ConvertModels
{
    public class AccountToLoginVMConverter
    {
        public Account ConvertToModel(LoginViewModel lvm)
        {
            Account acc = new Account()
            {
                Gebruikersnaam = lvm.Username,
                Wachtwoord = lvm.Password
            };

            return acc;
        }
    }
}
