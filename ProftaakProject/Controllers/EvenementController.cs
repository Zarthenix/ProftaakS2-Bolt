using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;
using ProftaakProject.Models.ViewModels.EventModels;
using ProftaakProject.Repositories;

namespace ProftaakProject.Controllers
{
    public class EvenementController : BaseController
    {
        private readonly EvenementRepo _evenementRepo;
        public EvenementController(EvenementRepo evr)
        {
            _evenementRepo = evr;
        }

        public IActionResult Index()
        {
            EvenementToEvenementVMConverter evmc = new EvenementToEvenementVMConverter();
            List<Evenement> evenementen = _evenementRepo.GetAllByUserId(GetUserId());
            List<EvenementViewModel> evm = new List<EvenementViewModel>();

            foreach (Evenement ev in evenementen)
            {
                evm.Add(evmc.ConvertToViewModel(ev));
            }

            return View(evm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EvenementViewModel evm = new EvenementViewModel();
            return View(evm);
        }

        [HttpPost]
        public IActionResult Create(EvenementViewModel evm)
        {
            Evenement ev = new Evenement();
            EvenementToEvenementVMConverter eevmc = new EvenementToEvenementVMConverter();
            ev = eevmc.ConvertToModel(evm);

            _evenementRepo.Create(ev, GetUserId());
            return View();
        }
    }
}