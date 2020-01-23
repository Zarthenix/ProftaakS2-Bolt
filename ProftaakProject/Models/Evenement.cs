using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ProftaakProject.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Account Host { get; set; }
        public string Omschrijving { get; set; }
        public string Locatie { get; set; }
        public DateTime Datum { get; set; }
        public int MaxDeelnemers { get; set; }
        public Uitzendbureau Uitzendbureau { get; set; }

        public Evenement()
        {

        }

        public Evenement(int id)
        {
            Id = id;
        }
    }
}
