using System;
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
    public class UitzendController : BaseController
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
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }
            UitzendViewModel uvm = new UitzendViewModel();
            uvm.Ingelogd = ar.GetByID(GetUserId());
            uvm.ubs = new List<Uitzendbureau>();
            if (User.IsInRole("Admin"))
            {
                uvm.ubs = ur.GetAll();
            }
            else
            {
                if(ur.GetByAccountID(uvm.Ingelogd.Id) == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    uvm.ubs.Add(ur.GetByAccountID(uvm.Ingelogd.Id));
                }
                
            }
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
        public IActionResult Uitzendbureau(int id, UitzendViewModel uvm)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }
            if (!User.IsInRole("Admin") && !ur.CheckIfAccountInUitzend(GetUserId())) { return RedirectToAction("Index", "Home"); }
            UitzendToUitzendvmConvert utuvmc = new UitzendToUitzendvmConvert();
            uvm = utuvmc.ConvertToViewModel(ur.GetByID(id));
            uvm.AccountTeVerwijderen = new Account(0, "");
            uvm.avm = ur.GetUitzendAccounts(id);
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
            //if (!User.IsInRole("Admin")) { return RedirectToAction("NotAuthorized", "Home"); }

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

                Uitzendbureau ub = new Uitzendbureau(id);

                ur.VoegToeAccountUitzend(id, avm.Gebruikersnaam);
                return RedirectToAction("Uitzendbureau", "Uitzend", new { id = ub.Id });
            }
            return View(avm);
        }

        [HttpGet]
        public IActionResult VerwijderGebruiker(int UitzendID, int AccountID)
        {
            ur.VerwijderAccountUitzend(AccountID);
            return RedirectToAction("Uitzendbureau", "Uitzend", new { id = UitzendID });
        }
    }
}