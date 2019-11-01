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
        public string Host { get; set; }
        public string Locatie { get; set; }
        public DateTime Datum { get; set; }
        public Evenement()
        {

        }
    }
}
