﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Models
{
    public class Reactie
    {
        public int Id { get; set; }
        public int GoedgekeurdDoor { get; set; }
        public string Inhoud { get; set; }
        public DateTime Datum { get; set; }
        public bool Goedgekeurd { get; set; }
        public int PostID { get; set; }
        public Account Auteur { get; set; }
        public Reactie()
        {

        }
    }
}
