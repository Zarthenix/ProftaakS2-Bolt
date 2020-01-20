using ProftaakProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ConvertModels
{
    public class AccountToProfielvmConvert
    {
        public Account ConvertToModel(ProfielViewModel pvm)
        {
            Account acc = new Account();
            {
                acc.Id = pvm.Id;
                acc.Naam = pvm.Naam;
                acc.Email = pvm.Email;
                acc.Geslacht = pvm.Geslacht;
                acc.Geboortedatum = pvm.Geboortedatum;
                acc.Rol = pvm.Rol;
            }
            return acc;
        }

        public ProfielViewModel ConvertToViewModel(Account acc)
        {
            ProfielViewModel pvm = new ProfielViewModel();
            {
                pvm.Id = acc.Id;
                pvm.Naam = acc.Naam;
                pvm.Email = acc.Email;
                pvm.Geslacht = acc.Geslacht;
                pvm.Geboortedatum = acc.Geboortedatum;
                pvm.Rol = acc.Rol;
            }
            return pvm;
        }
    }
}
