using System;

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
        public enum Type
        {
            artikel,
            vraag,
            reactie
        }

        public bool Goedgekeurd { get; set; }
        public Post(int id, string titel, string inhoud)
        {
            this.Id = id;
            this.Titel = titel;
            this.Inhoud = inhoud;
        }

        public Post()
        {

        }

        public Post(int id)
        {

        }
    }
}
