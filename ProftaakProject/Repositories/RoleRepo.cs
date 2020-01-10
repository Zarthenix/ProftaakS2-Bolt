using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.Repositories 
{
    public class RoleRepo
    {
        private IRoleContext roleContext;

        public RoleRepo (IRoleContext rolContext)
        {
            roleContext = rolContext;
        }

        public List<Role> GetAllRole()
        {
            return roleContext.GetAllRole();
        }

      

    }
}
