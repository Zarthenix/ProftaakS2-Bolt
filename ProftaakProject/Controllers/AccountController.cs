using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProftaakProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registratie()
        {
            return View();
        }

        public IActionResult Profiel()
        {
            return View();
        }
        public IActionResult ProfielBewerken()
        {
            return View("Profiel");
        }

    }

}