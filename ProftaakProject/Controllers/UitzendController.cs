using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Models;
using ProftaakProject.Models.ConvertModels;

namespace ProftaakProject.Controllers
{
    public class UitzendController : Controller
    {

        private UitzendRepo ur;

        public UitzendController(UitzendRepo uitzendrepo)
        {
            this.ur = uitzendrepo;
        }

        public IActionResult Index()
        {
            UitzendViewModel uvm = new UitzendViewModel();
            uvm.ubs = ur.GetAll();
            return View(uvm);

        }
    }
}