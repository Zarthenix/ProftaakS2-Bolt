using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels.EventModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class EvenementToEvenementVMConverter
    {
        public EvenementViewModel ConvertToViewModel(Evenement ev)
        {
            EvenementViewModel evm = new EvenementViewModel()
            {
                Id = ev.Id,
                Naam = ev.Naam,
                HostId = ev.Host.Id,
                Omschrijving = ev.Omschrijving,
                HostNaam = ev.Host.Naam,
                Locatie = ev.Locatie,
                Datum = ev.Datum,
                MaxDeelnemers = ev.MaxDeelnemers
            };

            return evm;
        }

        public Evenement ConvertToModel(EvenementViewModel evm)
        {
            Evenement ev = new Evenement(evm.Id)
            {
                Host = new Account(evm.HostId, evm.HostNaam),
                Locatie = evm.Locatie,
                Omschrijving = evm.Omschrijving,
                Datum = evm.Datum,
                MaxDeelnemers = evm.MaxDeelnemers,
                Naam = evm.Naam
            };
            return ev;
        }
    }
}
