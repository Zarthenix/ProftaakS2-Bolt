﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProftaakApplicatieS2.Models.ViewModels;

namespace ProftaakApplicatieS2.Models.Automap_Profiles
{
    public class VraagProfile : Profile
    {
        public VraagProfile()
        {
            CreateMap<Post, VraagViewModel>();
        }
    }
}
