using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models.ConvertModels;
using ProftaakProject.Models;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models.ViewModels.Post;
using ProftaakProject.Models.Repositories;
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
            ArtikelViewModel avm = new ArtikelViewModel()
            {
                post = pr.GetByID(id)
            };
            return View("Artikel", avm);
        }

        [HttpGet]
        public IActionResult PostToevoegen()
        {
            PostViewModel pvm = new PostViewModel();
            return View(pvm);
        }
        [HttpPost]
        public IActionResult PostToevoegen(PostViewModel pvm)
        {
            PostToPostvmConverter ptpvmc = new PostToPostvmConverter();
            Post post = ptpvmc.ConvertToModel(pvm);
            pr.Create(post);
            //return View(pvm);
            return RedirectToAction("ShowPost", "Post", new { id = post.Id });
        }

        public IActionResult ShowPost(int id)
        {
            PostToPostvmConverter ptpvmc = new PostToPostvmConverter();

            Post post = pr.GetByID(id);
            PostViewModel pvm = ptpvmc.ConvertToViewModel(post);
            return View(pvm);
        }
    }
}