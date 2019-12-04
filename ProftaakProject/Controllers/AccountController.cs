using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;

namespace ProftaakProject.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepo ar;

        public AccountController(AccountRepo accountRepo)
        {
            this.ar = accountRepo;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registratie()
        {
            return View();
        }

        public IActionResult Profiel(int id)
        {
            if (ModelState.IsValid)
            {
                AccountToProfielvmConvert atpvmc = new AccountToProfielvmConvert();

                Account ac = ar.GetByID(id);
                ac.Id = id;

                ProfielViewModel pvm = atpvmc.ConvertToViewModel(ac);
                List<ProfielViewModel> pvms = new List<ProfielViewModel>();
                pvm.Account = ar.GetByID(id); //Getall Context heeft geen geslacht en geboortedatum
                return View(pvm);
            }
            
            return View("Profiel");

        }

        [HttpPost]
        public IActionResult ProfielBewerken(ProfielViewModel pvm)
        {
            return View("Profiel", pvm);
        }

    }

}