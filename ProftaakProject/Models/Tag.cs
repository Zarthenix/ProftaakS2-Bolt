using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Tag(int id, string naam)
        {
            this.Id = id;
            this.Naam = naam;
        }

        public Tag()
        {

        }
    }
}
