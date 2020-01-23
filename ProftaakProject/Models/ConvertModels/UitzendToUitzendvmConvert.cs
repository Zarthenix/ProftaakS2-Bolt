using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Models.ViewModels;

namespace ProftaakProject.Models.ConvertModels
{
    public class UitzendToUitzendvmConvert
    {
        public Uitzendbureau ConvertToModel(UitzendViewModel uvm)
        {
            Uitzendbureau ub = new Uitzendbureau(uvm.Id);
            {
                ub.Naam = uvm.Naam;
                ub.Eigenaar = uvm.Eigenaar;
            }
            return ub;
        }

        public UitzendViewModel ConvertToViewModel(Uitzendbureau ub)
        {
            UitzendViewModel uvm = new UitzendViewModel();
            {
                uvm.Id = ub.Id;
                uvm.Naam = ub.Naam;
                uvm.Eigenaar = ub.Eigenaar;
            }
            return uvm;
        }
    }
}
