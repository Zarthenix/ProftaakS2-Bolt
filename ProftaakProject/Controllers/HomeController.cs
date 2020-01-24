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
        private ReactieRepo reactieRepo;

        public HomeController(ILogger<HomeController> logger, PostRepo prepo, AccountRepo arepo, ReactieRepo rrepo)
        {
            _logger = logger;
            this.postRepo = prepo;
            this.accountRepo = arepo;
            this.reactieRepo = rrepo;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(int sorteerInt)
        {
            PostViewModel pvm = new PostViewModel();
            pvm.HuidigeAccount = new AccountViewModel();
            pvm.HuidigeAccount.GeabonneerdeTags = new List<Tag>();
            List<PostViewModel> tempModels = new List<PostViewModel>();
            PostToPostvmConverter ppc = new PostToPostvmConverter();
            Account sessionAccount = new Account(-1);
            List<Post> posts;
            if (User.Identity.IsAuthenticated)
            {
                sessionAccount = accountRepo.GetByID(GetUserId());
                pvm.HuidigeAccount.GeabonneerdeTags = postRepo.GetAllGeabonneerdeTags(GetUserId());
            }

            if (sorteerInt == 0)
            { posts = postRepo.GetAllArtikelen(); }
            else
            { posts = postRepo.GetAllArtikelenByAantalBekeken(); }
            pvm.sorteerInt = sorteerInt;
            foreach (Post tempPost in posts)
            {
                if (tempPost.Uitzendbureau.Id == sessionAccount.UitzendID || tempPost.Uitzendbureau.Id == 0 || User.IsInRole("Admin"))
                {
                    tempPost.Auteur = accountRepo.GetByID(tempPost.Auteur.Id);
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


        [HttpGet]
        public IActionResult SearchResult(string query)
        {
            if (String.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index");
            }
            var userId = 0;
            if (User.Identity.IsAuthenticated)
            {
                userId = GetUserId();
            }
            List<Post> posts = postRepo.SearchResult(query, userId);
            if (posts.Count != 0)
            {
                PostToPostvmConverter pvmc = new PostToPostvmConverter();
                List<PostViewModel> postsViewModels = new List<PostViewModel>();

                foreach (Post p in posts)
                {
                    postsViewModels.Add(pvmc.ConvertToViewModel(p));
                }
                return View(postsViewModels);
            }
            ViewData["NoneFound"] = "Geen artikelen of vragen gevonden die overeen komen met de zoekopdracht.";
            return View(new List<PostViewModel>());
        }

        public IActionResult Notificaties()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }
            var vvm = new VraagViewModel();
            vvm.Reacties = new List<Reactie>();
            foreach (Post p in postRepo.GetAllVragenByID(GetUserId()))
            {
                foreach (Reactie r in reactieRepo.GetAll(p.Id))
                {
                    vvm.Reacties.Add(r);
                }
            }
            return View(vvm);
        }
    }
}
