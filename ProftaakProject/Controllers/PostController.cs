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

        #region Vraag

        public IActionResult Vraag(int id)
        {
            PostToVraagvmConverter ptavmc = new PostToVraagvmConverter();
            VraagViewModel vvm = ptavmc.ConvertToViewModel(pr.GetByID(id));
            return View(vvm);
        }

        [HttpGet]
        public IActionResult VraagToevoegen(int id)
        {
            if (id > 0)
            {
                PostToVraagToevoegenvmConverter ptvtvmc = new PostToVraagToevoegenvmConverter();
                Post p = pr.GetByID(id);
                VraagToevoegenViewModel vtvm = ptvtvmc.ConvertToViewModel(p);
                return View(vtvm);
            }
            else
            {
                VraagToevoegenViewModel vtvm = new VraagToevoegenViewModel();
                return View(vtvm);
            }

        }

        [HttpPost]
        public IActionResult VraagToevoegen(VraagToevoegenViewModel vtvm)
        {
            PostToVraagToevoegenvmConverter ptvtvmc = new PostToVraagToevoegenvmConverter();
            vtvm.TypeId = 1;
            Post post = ptvtvmc.ConvertToModel(vtvm);
            pr.Save(post);
            return RedirectToAction("Vraag", "Post", new { id = post.Id });
        }

        public IActionResult VraagVerwijderen(VraagToevoegenViewModel vtvm)
        {
            pr.Delete(vtvm.Id);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Artikel
        public IActionResult Artikel(int id)
        {
            PostToArtikelvmConverter pac = new PostToArtikelvmConverter();
            ArtikelViewModel avm = pac.ConvertToViewModel(pr.GetByID(id));

            return View("Artikel", avm);
        }
        [HttpGet]
        public IActionResult ArtikelToevoegen(int id)
        {
            ArtikelToevoegenViewModel atvm = new ArtikelToevoegenViewModel();
            atvm.Tags = pr.GetAllTags();
            if (id > 0)
            {
                PostToArtikelToevoegenvmConverter ptatvmc = new PostToArtikelToevoegenvmConverter();
                Post p = pr.GetByID(id);
                atvm = ptatvmc.ConvertToViewModel(p);
            }
            return View(atvm);

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

        public IActionResult FAQ()
        {
            return View();
        }
        #endregion

        #region Reactie
        #endregion
    }
}