using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakApplicatieS2.Models
{
    public class Reactie
    {
        public int ID { get; set; }
        public int GoedgekeurdDoor { get; set; }
        public string inhoud { get; set; }
        public DateTime Datum { get; set; }
        public bool Goedgekeurd { get; set; }
        public Reactie()
        {

        }
    }
}
