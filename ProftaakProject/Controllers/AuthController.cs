using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models.ViewModels.AccountModels;

namespace ProftaakProject.Controllers
{
    public class AuthController : BaseController
    {
        private AccountToRegisterVMConverter rvmc;
        private AccountToLoginVMConverter lvmc;
        private AccountRepo accRepo;
        private UserManager<Account> userManager;
        private SignInManager<Account> signInManager;

        public AuthController
          (AccountToLoginVMConverter lvmc, AccountToRegisterVMConverter rvmc, SignInManager<Account> signInManager,
          UserManager<Account> userManager, AccountRepo accRepo)
        {
            this.lvmc = lvmc;
            this.rvmc = rvmc;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.accRepo = accRepo;
        }

        public IActionResult Index()
        {
            LoginViewModel lvm = new LoginViewModel();
            return View("Login", lvm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            IActionResult retval = null;

            Account user = lvmc.ConvertToModel(lvm);

            if (ModelState.IsValid)
            {
                bool result = await accRepo.Login(user);

                if (result)
                    retval = RedirectToAction("Privacy", "Home");
            }
            else retval = View();

            return retval;
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            return View(rvm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            //instellingen voor wachtwoord zijn: verplicht lowercase, verplicht uppercase, minimaal 6 karakters en 1 uniek karakter.
            //kan veranderd worden in Startup.cs

            IActionResult retval = View();

            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Profile", new { id = GetUserId() });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Account user = rvmc.ConvertToModel(rvm);
                    bool result = await accRepo.Register(user, 1);

                    if (result)
                    {
                        await accRepo.Login(user);
                        retval = RedirectToAction("Index", "Profile", new { id = user.Id });
                    }
                }
            }
            return retval;
        }
    }
}