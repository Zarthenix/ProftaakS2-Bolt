using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProftaakProject.Controllers
{
    public class BaseController : Controller
    {
        protected virtual int GetUserId()
        {
            string rawValue = HttpContext.User.Identities.First().Claims.First().Value;
            if (string.IsNullOrEmpty(rawValue))
                return -1;

            if (int.TryParse(rawValue, out int id))
                return id;
            return -1;
        }
    }
}