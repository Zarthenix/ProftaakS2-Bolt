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
            Account acc = new Account(pvm.ProfielId);
            {
                acc.Naam = pvm.Naam;
                acc.Email = pvm.Email;
                acc.Geslacht = pvm.Geslacht;
                acc.Geboortedatum = pvm.Geboortedatum;
                acc.Rol = pvm.Rol;
            }
            return acc;
        }

        public ProfielViewModel ConvertToViewModel(Account acc, int gebruikerId)
        {
            ProfielViewModel pvm = new ProfielViewModel();
            {
                pvm.ProfielId = acc.Id;
                pvm.InlogId = gebruikerId;
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
