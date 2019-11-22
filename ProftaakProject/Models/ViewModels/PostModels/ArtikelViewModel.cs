using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models.ViewModels
{
    public class ArtikelViewModel
    {
        public int Id { get; set; }
        public Account Auteur { get; set; }
        public int GoedgekeurdDoor { get; set; }
        public int AantalBekenen { get; set; }
        public string Titel { get; set; }
        public DateTime Datum { get; set; }
        public string Inhoud { get; set; }
        public enum Type
        {

        }
        public bool Goedgekeurd { get; set; }
    }
}
