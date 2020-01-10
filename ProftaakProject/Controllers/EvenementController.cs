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
        private readonly EvenementToEvenementVMConverter _eevmc = new EvenementToEvenementVMConverter();
        public EvenementController(EvenementRepo evr)
        {
            _evenementRepo = evr;
        }

        public IActionResult Index()
        {
            List<Evenement> evenementen = _evenementRepo.GetAllByUserId(GetUserId());
            List<EvenementViewModel> evm = new List<EvenementViewModel>();

            foreach (Evenement ev in evenementen)
            {
                evm.Add(_eevmc.ConvertToViewModel(ev));
            }

            return View(evm);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Evenement ev = _evenementRepo.Read(id);
            EvenementViewModel evm = _eevmc.ConvertToViewModel(ev);
            return View();
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
            
            ev = _eevmc.ConvertToModel(evm);

            _evenementRepo.Create(ev, GetUserId());
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Evenement ev = _evenementRepo.Read(id);
            EvenementViewModel evm = _eevmc.ConvertToViewModel(ev);
            return View(evm);
        }

        [HttpPost]
        public IActionResult Edit(EvenementViewModel evm)
        {
            IActionResult retVal = View(evm);
            
            if (ModelState.IsValid)
            {
                Evenement ev = _eevmc.ConvertToModel(evm);
                bool result = _evenementRepo.Update(ev);

                if (result)
                {
                    retVal = RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error processing update.");
                }
            }
         
            return retVal;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _evenementRepo.Delete(id);

            return RedirectToAction("Index");
        }

    }
}