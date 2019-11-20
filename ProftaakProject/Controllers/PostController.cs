using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models.ViewModels;
namespace ProftaakProject.Controllers
{
    public class PostController : Controller
    {
        private PostRepo postRepo;

        public PostController(PostRepo prepo)
        {
            this.postRepo = prepo;
        }

        public IActionResult Vraag()
        {
            return View();
        }

        public IActionResult Artikel()
        {
            ArtikelViewModel avm = new ArtikelViewModel();
            avm.Titel = "TestArtikel";
            avm.Inhoud = "dit is lorem ipsum";
            avm.Id = 1;
            avm.AantalBekenen = 2;
            avm.Goedgekeurd = true;
            avm.GoedgekeurdDoor = 1;
            return View("Artikel",avm);
        }

        public IActionResult Home()
        {
            
        }

        public IActionResult PostToevoegen()
        {
            return View();
        }
    }
}