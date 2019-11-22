using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models
{
    public class Uitzendbureau
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Eigenaar { get; set; }
        public Uitzendbureau()
        {

        }

        public Uitzendbureau(int id)
        {

        }

        public Uitzendbureau(int id, string naam, int eigenaar)
        {
            this.Id = id;
            this.Naam = naam;
            this.Eigenaar = eigenaar;
        }
    }
}
