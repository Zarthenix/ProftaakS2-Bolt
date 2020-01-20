using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Role (int id, string naam)
        {
            this.Id = id;
            this.Naam = naam;
        }

        public Role()
        {

        }
    }
}
