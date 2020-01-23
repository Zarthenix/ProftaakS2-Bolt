using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models.ViewModels.EventModels;
using ProftaakProject.Repositories;

namespace ProftaakProject.Controllers
{
    public class EvenementController : BaseController
    {


        private readonly EvenementRepo _evenementRepo;
        private readonly UitzendRepo _uitzendRepo;
        private readonly EvenementToEvenementVMConverter _eevmc = new EvenementToEvenementVMConverter();
        public EvenementController(EvenementRepo evr, UitzendRepo urepo)
        {
            _evenementRepo = evr;
            _uitzendRepo = urepo;
        }

        public IActionResult Index()
        {
            List<Evenement> gebruikersEvenementen = _evenementRepo.GetAllByUserId(GetUserId());
            List<Evenement> uitzendEvenementen = _evenementRepo.GetAvailableEvents(GetUserId());

            EvenementIndexViewModel eivm = new EvenementIndexViewModel();

            foreach (Evenement ev in gebruikersEvenementen)
            {
                eivm.JoinedEvents.Add(_eevmc.ConvertToViewModel(ev));
            }

            foreach (Evenement ev in uitzendEvenementen)
            {
                eivm.AvailableEvents.Add(_eevmc.ConvertToViewModel(ev));
            }

            eivm.UserId = GetUserId();

            return View(eivm);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Evenement ev = _evenementRepo.Read(id);
            EvenementViewModel evm = _eevmc.ConvertToViewModel(ev);
            return View(evm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EvenementViewModel evm = new EvenementViewModel();
            return View(evm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EvenementViewModel evm)
        {
            if (ModelState.IsValid)
            {
                Evenement ev = _eevmc.ConvertToModel(evm);
                if (evm.EnkelUitzendbureau)
                {
                    ev.Uitzendbureau = _uitzendRepo.GetByAccountID(GetUserId());
                }
                else
                {
                    ev.Uitzendbureau = new Uitzendbureau(-1);
                }
                _evenementRepo.Create(ev, GetUserId());
                return RedirectToAction("Index");
            }
            return View(evm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Evenement ev = _evenementRepo.Read(id);
            EvenementViewModel evm = _eevmc.ConvertToViewModel(ev);
            return View(evm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            if (_evenementRepo.Read(id).Host.Id == GetUserId())
            {
                _evenementRepo.Delete(id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SignOut(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                _evenementRepo.SignOut(id, GetUserId());
            }
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SignIn(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                _evenementRepo.SignIn(id, GetUserId());
            }

            return RedirectToAction("Index");
        }

    }
}