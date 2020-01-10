using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProftaakProject.Models.ViewModels
{
    public class RolViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "Kies een nieuwe rol")]
        public int NieuwRolId { get; set; }
        public List<Role> AlleRollen { get; set; }

    }
}
