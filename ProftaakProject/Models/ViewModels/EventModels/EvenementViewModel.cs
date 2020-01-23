using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels.EventModels
{
    public class EvenementViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is vereist.")]
        [StringLength(50, ErrorMessage = "Maximum aantal tekens is 50.")]
        [DataType(DataType.Text)]
        [Display(Name="Naam")]
        public string Naam { get; set; }

        [Display(Name = "Datum")]
        [DataType(DataType.DateTime)]
  
        public DateTime Datum { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Kind);
        

        [Display(Name = "Organizator")]
        public int HostId { get; set; }

        public string HostNaam { get; set; }

        [DataType(DataType.Text)]
        public string Omschrijving { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Locatie")]
        [StringLength(50, ErrorMessage = "Maximaal 50 karakters.")]
        public string Locatie { get; set; }

        [Display(Name = "Maximaal aantal deelnemers.")]
        public int MaxDeelnemers { get; set; }

        [Display(Name="Alleen naar uitzendbureau posten.")]
        public bool EnkelUitzendbureau { get; set; }
    }
}
