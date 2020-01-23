using ProftaakProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ConvertModels
{
    public class AccountToAccountvmConvert
    {
        public Account ConvertToModel(AccountViewModel avm)
        {
            Account acc = new Account(avm.Id);
            {
                acc.Naam = avm.Naam;
                acc.Email = avm.Email;
                acc.Gebruikersnaam = avm.Gebruikersnaam;
            }
            return acc;
        }

        public AccountViewModel ConvertToViewModel(Account acc)
        {
            AccountViewModel avm = new AccountViewModel();
            {
                avm.Id = acc.Id;
                avm.Naam = acc.Naam;
                avm.Email = acc.Email;
                avm.Gebruikersnaam = acc.Gebruikersnaam;
            }
            return avm;
        }
   
    }
}
