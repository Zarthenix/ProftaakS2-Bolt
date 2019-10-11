using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProftaakApplicatieS2.Controllers
{
    public class UitzendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}