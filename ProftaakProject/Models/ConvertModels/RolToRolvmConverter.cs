using ProftaakProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ConvertModels
{
    public class RolToRolvmConverter
    {
        public Role ConvertToModel(RolViewModel rvm)
        {
            Role acc = new Role();
            {
                acc.Id = rvm.NieuwRolId;
            }
            return acc;
        }

        public RolViewModel ConvertToViewModel(Role acc)
        {
            RolViewModel rvm = new RolViewModel();
            {
                rvm.NieuwRolId = acc.Id;
            }
            return rvm;
        }
    }
}
