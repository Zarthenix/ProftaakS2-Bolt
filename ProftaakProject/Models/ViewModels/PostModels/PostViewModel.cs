using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProftaakProject.Models.ViewModels.PostModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public Account Auteur { get; set; }

        [Required(ErrorMessage = "Vul een titel in!")]
        public string Titel { get; set; }

        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Vul een inhoud in!")]
        public string Inhoud { get; set; }

        public string Tag { get; set; }

        public int TypeId { get; set; }

        public string ImageFile { get; set; }
        public enum Types
        {
            Artikel,
            Vraag,
            Reactie
        }
    }
}
