using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Host { get; set; }
        public string Locatie { get; set; }
        public DateTime Datum { get; set; }
        public int MaxDeelnemers { get; set; }
        public Evenement(int id)
        {
            Id = id;
        }
    }
}
