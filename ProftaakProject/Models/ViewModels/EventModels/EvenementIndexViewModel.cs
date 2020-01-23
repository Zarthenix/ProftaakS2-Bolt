using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels.EventModels
{
    public class EvenementIndexViewModel
    {
        public List<EvenementViewModel> JoinedEvents { get; set; } = new List<EvenementViewModel>();

        public List<EvenementViewModel> AvailableEvents { get; set; } = new List<EvenementViewModel>();

        public int UserId { get; set; }
    }
}
