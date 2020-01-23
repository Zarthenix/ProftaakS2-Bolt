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
            Account acc = new Account(rvm.Username, rvm.Password)
            {
                Email = rvm.Email,
                Naam = rvm.Name,
                Geslacht = (Gender)rvm.Gender,
                Geboortedatum = rvm.Birthday
            };
            return acc;
        }


    }
}
