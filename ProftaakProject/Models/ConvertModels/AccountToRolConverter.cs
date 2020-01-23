using ProftaakProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ConvertModels
{
    public class AccountToRolConverter
    {
        public Account ConvertToModel(RolViewModel rvm)
        {
            return new Account(rvm.UserId);
        }

        public RolViewModel ConvertToViewModel(Account acc)
        {
            RolViewModel rvm = new RolViewModel();
            {
                rvm.UserId = acc.Id;
            }
            return rvm;
        }
    }
}
