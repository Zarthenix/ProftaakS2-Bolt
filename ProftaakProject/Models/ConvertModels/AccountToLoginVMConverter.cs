using ProftaakProject.Models.ViewModels.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ConvertModels
{
    public class AccountToLoginVMConverter
    {
        public Account ConvertToModel(LoginViewModel lvm)
        {
            return new Account(lvm.Username, lvm.Password);
        }
    }
}
