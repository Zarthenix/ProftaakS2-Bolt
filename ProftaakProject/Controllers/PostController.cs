using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models.ConvertModels;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models.ViewModels.PostModels;
namespace ProftaakProject.Controllers
{
    public class PostController : Controller
    {

        private PostRepo pr;

        public PostController(PostRepo pr)
        {
            this.pr = pr;
        }

        public IActionResult Vraag()
        {
            return View();
        }

        public IActionResult Artikel(int id)
        {
            PostToArtikelvmConverter pac = new PostToArtikelvmConverter();
            ArtikelViewModel avm = pac.ConvertToViewModel(pr.GetByID(id));

            return View("Artikel", avm);
        }

        [HttpGet]
        public IActionResult ArtikelToevoegen(int id)
        {
            if (id > 0)
            {
                PostToArtikelToevoegenvmConverter ptatvmc = new PostToArtikelToevoegenvmConverter();
                Post p = pr.GetByID(id);
                ArtikelToevoegenViewModel atvm = ptatvmc.ConvertToViewModel(p);
                return View(atvm);
            }
            else
            {
                ArtikelToevoegenViewModel atvm = new ArtikelToevoegenViewModel();
                return View(atvm);
            }

        }
        [HttpPost]
        public IActionResult ArtikelToevoegen(ArtikelToevoegenViewModel atvm)
        {
            PostToArtikelToevoegenvmConverter ptatvmc = new PostToArtikelToevoegenvmConverter();
            atvm.TypeId = 0;
            Post post = ptatvmc.ConvertToModel(atvm);
            pr.Save(post);
            return RedirectToAction("Artikel", "Post", new { id = post.Id });
        }
        public IActionResult ArtikelVerwijderen(ArtikelToevoegenViewModel atvm)
        {
            pr.Delete(atvm.Id);
            return RedirectToAction("Index", "Home");
        }
    }
}