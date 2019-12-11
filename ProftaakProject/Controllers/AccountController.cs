using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models.ViewModels.AccountModels;

namespace ProftaakProject.Controllers
{
    public class AccountController : BaseController
    {
        private AccountRepo _accRepo;
        private AccountToRegisterVMConverter _rvmc = new AccountToRegisterVMConverter();
        private AccountToLoginVMConverter _lvmc = new AccountToLoginVMConverter();

        public AccountController(AccountRepo accRepo)
        {
            _accRepo = accRepo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            return View(lvm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            IActionResult retval = View(lvm);

            if (ModelState.IsValid)
            {
                Account user = _lvmc.ConvertToModel(lvm);
                bool result = await _accRepo.Login(user);

                if (result)
                    retval = RedirectToAction("Index", "Home");
            }

            return retval;
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _accRepo.Logout();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            RegisterViewModel rvm = new RegisterViewModel();
            return View("Registratie", rvm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            IActionResult retval = View("Registratie", rvm);

            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                retval = RedirectToAction("Profiel", new { id = GetUserId() });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Account user = _rvmc.ConvertToModel(rvm);
                    bool result = await _accRepo.Register(user, 1);

                    if (result)
                    {
                        await _accRepo.Login(user);
                        retval = RedirectToAction("Index", "Home");
                    }
                }
            }
            return retval;
        }

        [HttpGet]
        public IActionResult Profiel(int id)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }

            if (ModelState.IsValid)
            {
                AccountToProfielvmConvert atpvmc = new AccountToProfielvmConvert();

                Account ac = _accRepo.GetByID(id);
                ac.Id = id;

                ProfielViewModel pvm = atpvmc.ConvertToViewModel(ac);
                List<ProfielViewModel> pvms = new List<ProfielViewModel>();
                pvm.Account = _accRepo.GetByID(id); //Getall Context heeft geen geslacht en geboortedatum
                return View(pvm);
            }

            return View("Profiel");

        }

        [HttpPost]
        public IActionResult ProfielBewerken(ProfielViewModel pvm)
        {
            return View("Profiel", pvm);
        }

        [HttpGet]
        public IActionResult ResetWachtwoord()
        {
            return View();
        }
    }

}