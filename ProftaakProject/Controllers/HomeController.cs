using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PostRepo postRepo;

        public HomeController(ILogger<HomeController> logger, PostRepo prepo)
        {
            _logger = logger;
            this.postRepo = prepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            PostViewModel pvm = new PostViewModel();
            List<PostViewModel> tempModels = new List<PostViewModel>();
            PostToPostvmConverter ppc = new PostToPostvmConverter();

            foreach (Post tempPost in postRepo.GetAll())
            {
                tempModels.Add(ppc.ConvertToViewModel(tempPost));
            }

            pvm.PostViewModels = tempModels; 
            return View(pvm);
        }

        [HttpGet]
        public IActionResult Privacy()
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
    }
}
