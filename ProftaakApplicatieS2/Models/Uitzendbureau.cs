using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakApplicatieS2.Models
{
    public class Uitzendbureau
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public int Eigenaar { get; set; }
        public Uitzendbureau()
        {

        }
    }
}
