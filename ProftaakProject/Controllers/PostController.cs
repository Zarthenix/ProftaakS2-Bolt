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
using Microsoft.AspNetCore.Authorization;

namespace ProftaakProject.Controllers
{
    public class PostController : BaseController
    {

        private PostRepo pr;
        private ReactieRepo rr;
        private UitzendRepo ur;

        public PostController(PostRepo pr, ReactieRepo rr, UitzendRepo ur)
        {
            this.pr = pr;
            this.rr = rr;
            this.ur = ur;
        }

        #region Vraag

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Vraag(int id)
        {
            pr.IncrementViews(id);
            PostToVraagvmConverter ptavmc = new PostToVraagvmConverter();
            VraagViewModel vvm = ptavmc.ConvertToViewModel(pr.GetByID(id));
            vvm.Post.Id = id;
            vvm.Reacties = rr.GetAll(vvm.Post.Id);
            return View(vvm);
        }

        [HttpGet]
        public IActionResult VraagToevoegen(int id)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }

            VraagToevoegenViewModel vtvm = new VraagToevoegenViewModel();

            if (id > 0)
            {
                PostToVraagToevoegenvmConverter ptvtvmc = new PostToVraagToevoegenvmConverter();
                Post p = pr.GetByID(id);
                vtvm = ptvtvmc.ConvertToViewModel(p);
            }

            vtvm.Tags = pr.GetAllTags();

            return View(vtvm);
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

        [HttpPost]
        public IActionResult VraagVerwijderen(VraagViewModel vvm)
        {
            pr.Delete(vvm.Post.Id);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult FAQ()
        {
            FAQViewModel fvm = new FAQViewModel();
            foreach (Tag temptag in pr.GetAllTags())
            {
                fvm.PopulaireVragen.Add(pr.FAQVragenByTag(temptag));
            }

            return View(fvm);
        }
        #endregion

        #region Artikel
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Artikel(int id)
        {
            PostToArtikelvmConverter pac = new PostToArtikelvmConverter();
            ArtikelViewModel avm = pac.ConvertToViewModel(pr.GetByID(id));
            pr.IncrementViews(id);
            return View("Artikel", avm);
        }

        [HttpGet]
        public IActionResult ArtikelToevoegen(int id)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }

            ArtikelToevoegenViewModel atvm = new ArtikelToevoegenViewModel();
            if (id > 0)
            {
                PostToArtikelToevoegenvmConverter ptatvmc = new PostToArtikelToevoegenvmConverter();
                Post p = pr.GetByID(id);
                atvm = ptatvmc.ConvertToViewModel(p);
            }
            var tempub = ur.GetByAccountID(GetUserId());
            if (tempub.Id > 0)
                atvm.Uitzendbureau = tempub;
            atvm.Tags = pr.GetAllTags();
            return View(atvm);
        }

        [HttpPost]
        public IActionResult ArtikelToevoegen(ArtikelToevoegenViewModel atvm)
        {
            if (atvm.ImageFile != null)
            {
                PostToArtikelToevoegenvmConverter ptatvmc = new PostToArtikelToevoegenvmConverter();
                atvm.TypeId = 0;
                var tempub = new Uitzendbureau();
                atvm.Uitzendbureau = tempub;
                if (atvm.HeeftUitzendbureau)
                {
                    tempub = ur.GetByAccountID(GetUserId());
                    if (tempub.Id > 0)
                        atvm.Uitzendbureau = tempub;
                }
                Post post = ptatvmc.ConvertToModel(atvm);
                pr.Save(post);
                return RedirectToAction("Artikel", "Post", new { id = post.Id });
            }
            else return View(atvm);
        }

        [HttpGet]
        public IActionResult LijstArtikelGoedkeuren()
        {
            LijstArtikelGoedkeurenViewModel lagvm = new LijstArtikelGoedkeurenViewModel();
            lagvm.Posts = pr.GetAllArtikelenGoedkeuren();
            return View(lagvm);
        }

        [HttpGet]
        public IActionResult ArtikelGoedkeuren(int Id)
        {
            ArtikelGoedkeurenViewModel agvm = new ArtikelGoedkeurenViewModel();
            agvm.Post = pr.GetByID(Id);
            return View(agvm);
        }
        
        [HttpGet]
        public IActionResult ArtikelVerwijderen(ArtikelToevoegenViewModel atvm)
        {
            if (!User.IsInRole("Admin")) { return RedirectToAction("NotAuthorized", "Home"); }

            pr.Delete(atvm.Id);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Reactie
        [HttpPost]
        public IActionResult ReactieAanmaken(VraagViewModel vvm)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == false) { return RedirectToAction("Login", "Account"); }

            if (!ModelState.IsValid)
            {
                PostToVraagvmConverter ptavmc = new PostToVraagvmConverter();
                VraagViewModel tempvvm = ptavmc.ConvertToViewModel(pr.GetByID(vvm.Post.Id));
                tempvvm.Reacties = rr.GetAll(vvm.Post.Id);
                return View("Vraag", tempvvm);
            }
            vvm.ReactieAanmaken.Datum = DateTime.Now;
            vvm.ReactieAanmaken.PostID = vvm.Post.Id;
            vvm.ReactieAanmaken.Inhoud = vvm.ReactieInhoud;
            rr.Create(vvm.ReactieAanmaken);
            return RedirectToAction("Vraag", "Post", new { id = vvm.Post.Id });
        }

        public IActionResult ReactieVerwijderen(int ReactieID, int VraagID)
        {
            if (!User.IsInRole("Admin")) { return RedirectToAction("NotAuthorized", "Home"); }

            rr.Delete(ReactieID);
            return RedirectToAction("Vraag", "Post", new { id = VraagID });
        }
        #endregion

        [HttpPost]
        public IActionResult Goedkeuren(int postId)
        {
            pr.UpdateGoedgekeurd(GetUserId(), postId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Afkeuren(int postId)
        {
            pr.UpdateGoedgekeurd(-1, postId);
            return RedirectToAction("Index", "Home");
        }

    }
}