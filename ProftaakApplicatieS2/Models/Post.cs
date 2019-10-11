using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakApplicatieS2.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int GoedgekeurdDoor { get; set; }
        public int AantalBekenen { get; set; }
        public string Onderwerp { get; set; }
        public DateTime Datum { get; set; }
        public string Inhoud { get; set; }
        public enum Type
        {

        }
        public bool Goedgekeurd { get; set; }
        public Post()
        {

        }

    }
}
