using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProftaakProject.Models.ViewModels;
using ProftaakProject.Models;

namespace ProftaakProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper) => _mapper = mapper;

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registratie()
        {
            AccountViewModel avm = new AccountViewModel();
            return View(avm);
        }

        [HttpPost]
        public IActionResult Registratie(AccountViewModel avm)
        {
            Account user = _mapper.Map<Account>(avm);
            Console.WriteLine(user.Id);
            Console.WriteLine(user.Gebruikersnaam);
            Console.WriteLine(user.Email);

            return RedirectToAction("Index", "Home");
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