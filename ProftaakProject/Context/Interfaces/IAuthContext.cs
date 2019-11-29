using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IAuthContext
    {
        Task<bool> Login(Account user);
        Task<bool> Register(Account user, int rol);
    }
}
