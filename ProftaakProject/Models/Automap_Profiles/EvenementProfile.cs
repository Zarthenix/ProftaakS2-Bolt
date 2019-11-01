using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProftaakProject.Models.ViewModels;

namespace ProftaakProject.Models.Automap_Profiles
{
    public class EvenementProfile : Profile
    {
        public EvenementProfile()
        {
            CreateMap<Evenement, EvenementViewModel>();
        }
    }
}
