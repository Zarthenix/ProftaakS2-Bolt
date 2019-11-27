using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using ProftaakProject.Models.ViewModels.PostModels;

namespace ProftaakProject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Account Auteur { get; set; }
        public int GoedgekeurdDoor { get; set; }
        public int AantalBekenen { get; set; }
        public string Titel { get; set; }
        public DateTime Datum { get; set; }
        public string Inhoud { get; set; }
        public int TypeId { get; set; }
        public byte[] ImageFile { get; set; }
        public enum Types
        {
            Artikel,
            Vraag,
            Reactie
        }

        public bool Goedgekeurd { get; set; }
        public Post(int id, string titel, string inhoud, int typeId, byte[] imageFile)
        {
            this.Id = id;
            this.Titel = titel;
            this.Inhoud = inhoud;
            this.TypeId = typeId;
            this.ImageFile = imageFile;
        }

        public Post()
        {

        }

        public Post(int id)
        {

        }
    }
}
