using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models.ViewModels.PostModels;

namespace ProftaakProject.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private PostRepo postRepo;
        private AccountRepo accountRepo;

        public HomeController(ILogger<HomeController> logger, PostRepo prepo, AccountRepo arepo)
        {
            _logger = logger;
            this.postRepo = prepo;
            this.accountRepo = arepo;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            PostViewModel pvm = new PostViewModel();
            pvm.HuidigeAccount = new AccountViewModel();
            pvm.HuidigeAccount.GeabonneerdeTags = new List<Tag>();
            List<PostViewModel> tempModels = new List<PostViewModel>();
            PostToPostvmConverter ppc = new PostToPostvmConverter();
            Account sessionAccount = new Account();
            if (User.Identity.IsAuthenticated)
            {
                sessionAccount = accountRepo.GetByID(GetUserId());
            }
            if (User.Identity.IsAuthenticated)
            {
                pvm.HuidigeAccount.GeabonneerdeTags = postRepo.GetAllGeabonneerdeTags(GetUserId());
            }
            foreach (Post tempPost in postRepo.GetAllArtikelen())
            {
                if (tempPost.Uitzendbureau.Id == sessionAccount.UitzendID || tempPost.Uitzendbureau.Id == 0 || User.IsInRole("Admin"))
                {
                    tempModels.Add(ppc.ConvertToViewModel(tempPost));
                }
            }
            pvm.PostViewModels = tempModels;
            return View(pvm);
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OnGetPartial() =>
            PartialView("_Post");


        //Zoek functie
        public IActionResult SearchResult()
        {
            return View();
        }
    }
}
