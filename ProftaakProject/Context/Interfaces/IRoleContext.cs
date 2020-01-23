using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface IRoleContext
    {
        List<Role> GetAllRole();

        bool Update(int userId, int roleId);

        Role GetByUserId(int id);

    }
}
