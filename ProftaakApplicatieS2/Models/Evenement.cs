using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakApplicatieS2.Models
{
    public class Evenement
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Host { get; set; }
        public string Locatie { get; set; }
        public DateTime Datum { get; set; }
        public Evenement()
        {

        }
    }
}
