using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models.ViewModels.AccountModels;
using ProftaakProject.Repositories;

namespace ProftaakProject.Controllers
{
    public class AccountController : BaseController
    {
        private AccountRepo _accRepo;
        private AccountToRegisterVMConverter _rvmc = new AccountToRegisterVMConverter();
        private AccountToLoginVMConverter _lvmc = new AccountToLoginVMConverter();
        private RoleRepo _roleRepo;
        private PostRepo _postRepo;

        public AccountController(AccountRepo accRepo, RoleRepo roleRepo, PostRepo postRepo)
        {
            _accRepo = accRepo;
            _roleRepo = roleRepo;
            _postRepo = postRepo;
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
                    bool result = await _accRepo.Register(user, 0);

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
        public IActionResult Profiel(int? id)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }
            Account ac;

            if (id == null)
            {
                ac = _accRepo.GetByID(GetUserId());
            }
            else
            {
                ac = _accRepo.GetByID((int)id);
            }
            ProfielViewModel prvm = new ProfielViewModel();
            AccountToProfielvmConvert atpvmc = new AccountToProfielvmConvert();
            prvm = atpvmc.ConvertToViewModel(ac, GetUserId());

            return View(prvm);
        }

        [HttpGet]
        public IActionResult ProfielBewerken()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }
            ProfielViewModel prvm = new ProfielViewModel();
            AccountToProfielvmConvert atpvmc = new AccountToProfielvmConvert();
            Account ac = _accRepo.GetByName(HttpContext.User.Identity.Name);
            prvm = atpvmc.ConvertToViewModel(ac, GetUserId());
            return View(prvm);
        }

        [HttpPost]
        public IActionResult ProfielOpslaan(ProfielViewModel prvm)
        {
            AccountToProfielvmConvert atpvmc = new AccountToProfielvmConvert();
            _accRepo.Update(atpvmc.ConvertToModel(prvm));
            return RedirectToAction("Profiel", "Account");
        }

        [HttpGet]
        public IActionResult ResetWachtwoord()
        {

            return View();
        }

        [Authorize]
        public IActionResult AccountLijst()
        {
            AccountViewModel avm = new AccountViewModel();
            avm.accs = _accRepo.GetAll();

            return View(avm);
        }

        public IActionResult Verwijder(AccountViewModel avm)
        {
            _accRepo.Delete(avm.Id);

            return RedirectToAction("AccountLijst", "Account");
        }

        ////[HttpGet]
        //public IActionResult Rol()
        //{
        //    List<Rol> rols = _accRepo.GetAll();

        //    AccountViewModel avm = new AccountViewModel()
        //    {
        //        accs = rols
        //    };
        //    return View();
        //}

        [HttpGet]
        public IActionResult RolGeven(int userId)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }

            RolViewModel avm = new RolViewModel()
            {
                AlleRollen = _roleRepo.GetAllRole(),
                UserId = userId
            };

            return View(avm);
        }

        [HttpGet]
        public IActionResult Geschiedenis()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }
            GeschiedenisViewModel gvm = new GeschiedenisViewModel();
            PostToPostvmConverter pvc = new PostToPostvmConverter();
            List<Post> postList = _accRepo.GetAllPostsOfUser(GetUserId());
            foreach (var post in postList)
            {
                gvm.Posts.Add(pvc.ConvertToViewModel(post));
            }
            return View(gvm);
        }
        [HttpPost]
        public IActionResult RolOpslaan(RolViewModel rvm)
        {
            //AccountToRolConverter atrvmc = new AccountToRolConverter();
            if (rvm.NieuwRolId != _roleRepo.GetByUserId(rvm.UserId).Id)
            {
                _roleRepo.Update(rvm.UserId, rvm.NieuwRolId);
            }
            return RedirectToAction("Profiel", "Account");
        }


        //[HttpGet]
        //public IActionResult Accountlijst()
        //{

        //    AccountViewModel avm = new AccountViewModel()
        //    {
        //        accs = _accRepo.GetAll()
        //    };

        //    return View(avm);
        //}

        //[HttpPost]
        //public IActionResult Accountlijst(AccountViewModel avm)
        //{
        //    return View(avm);
        //}

        //[HttpGet]
        //public IActionResult Accounts(/*int id, AccountViewModel avms*/)
        //{
        //    if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }

        //    AccountToAccountvmConvert atavmc = new AccountToAccountvmConvert();
        //    Account ac = ur.GetByID(id);
        //    ac.Id = id;
        //    avms = atamc.ConvertToViewModel(ac);
        //    List<AccountViewModel> avms = new List<AccountViewModel>();
        //    avms.avm = ur.GetUitzendAccounts(id);
        //    return View(/*avms*/);
        //}
    }

}