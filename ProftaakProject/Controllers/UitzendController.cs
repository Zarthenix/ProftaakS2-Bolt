﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;
using Microsoft.AspNetCore.Authorization;

namespace ProftaakProject.Controllers
{
    public class UitzendController : Controller
    {

        private UitzendRepo ur;
        private AccountRepo ar;

        public UitzendController(UitzendRepo uitzendrepo, AccountRepo accountRepo)
        {
            this.ur = uitzendrepo;
            this.ar = accountRepo;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            UitzendViewModel uvm = new UitzendViewModel();
            uvm.ubs = ur.GetAll();
            return View(uvm);
        }

        [HttpGet]
        public IActionResult UitzendToevoegen()
        {
            if (!User.IsInRole("Admin")) { return RedirectToAction("NotAuthorized", "Home"); }

            UitzendViewModel uvm = new UitzendViewModel();
            uvm.Id = -1;
            return View(uvm);
        }

        [HttpPost]
        public IActionResult UitzendToevoegen(UitzendViewModel uvm)
        {
            
            if (ModelState.IsValid)
            {
                UitzendToUitzendvmConvert utuvmc = new UitzendToUitzendvmConvert();
                Uitzendbureau ub = utuvmc.ConvertToModel(uvm);
                ur.Check(ub);
                return RedirectToAction("Uitzendbureau", "Uitzend", new { id = ub.Id });
            }
            return View(uvm);
        }

        [HttpPost]
        public IActionResult UitzendBewerken(UitzendViewModel uvm)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }

            return View("UitzendToevoegen", uvm);
        }
        
        [HttpGet]
        public IActionResult Uitzendbureau(int id)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }

            UitzendToUitzendvmConvert utuvmc = new UitzendToUitzendvmConvert();

            Uitzendbureau ub = ur.GetByID(id);
            ub.Id = id;

            UitzendViewModel uvm = utuvmc.ConvertToViewModel(ub);
            List<AccountViewModel> avms = new List<AccountViewModel>();
            //uvm.avm = avms;
            uvm.avm = ar.GetAllUitzend(id);
            return View(uvm);
        }

        [HttpGet]
        public IActionResult VerwijderUb(int id)
        {
            if (!User.IsInRole("Admin")) { return RedirectToAction("NotAuthorized", "Home"); }

            ur.Delete(id);
            return RedirectToAction("Index", "Uitzend");
        }

        [HttpGet]
        public IActionResult AccountToevoegen()
        {
            if (!User.IsInRole("Admin")) { return RedirectToAction("NotAuthorized", "Home"); }

            AccountViewModel avm = new AccountViewModel();

            avm.accs = ar.GetAll();

            return View(avm);
        }

        [HttpPost]
        public IActionResult AccountToevoegen(AccountViewModel avm, int id)
        {

            if (ModelState.IsValid)
            {
                AccountToAccountvmConvert atavmc = new AccountToAccountvmConvert();
                Account acc = atavmc.ConvertToModel(avm);

                Uitzendbureau ub = new Uitzendbureau();
                ub.Id = id;

                //ar.VoegToeUitzend();
                return RedirectToAction("Uitzendbureau", "Uitzend", new { id = ub.Id });
            }
            return View(avm);
        }

        [HttpPost]
        public IActionResult VerwijderGebruiker(UitzendViewModel uvm)
        {
            ar.VerwijderUitzend(uvm.AccountTeVerwijderen.Id);
            return RedirectToAction("Uitzendbureau", "Uitzend", new { id = uvm.Id });
            //return 
        }
    }
}