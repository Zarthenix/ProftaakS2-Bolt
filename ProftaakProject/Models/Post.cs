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
        public bool Uitgelicht { get; set; }
        public string Titel { get; set; }
        public DateTime Datum { get; set; }
        public string Inhoud { get; set; }
        public int TypeId { get; set; }
        public Tag Tag { get; set; }
        public byte[] ImageFile { get; set; }
        public enum Types
        {
            Artikel,
            Vraag,
            Reactie
        }
        public Uitzendbureau Uitzendbureau { get; set; }

        public Post(int id, string titel, string inhoud, int typeId, Tag tag, int goedgekeurdDoor, Account account, byte[] imageFile, bool uitgelicht, int uitzendID)
        {
            this.Id = id;
            this.Titel = titel;
            this.Inhoud = inhoud;
            this.TypeId = typeId;
            this.Tag = tag;
            this.GoedgekeurdDoor = goedgekeurdDoor;
            this.Auteur = account;
            this.ImageFile = imageFile;
            this.Uitzendbureau = new Uitzendbureau(uitzendID);
            this.Uitgelicht = uitgelicht;
        }

        public Post(int id, string titel, int type, string inhoud, DateTime datum, Account auteur, int aantalBekeken)
        {
            this.Id = id;
            this.Titel = titel;
            this.TypeId = type;
            this.Datum = datum;
            this.Inhoud = inhoud;
            this.Auteur = auteur;
            this.AantalBekenen = aantalBekeken;
        }

        public Post(int id, string titel, string inhoud, int typeId, Tag tag, int goedgekeurdDoor, byte[] imageFile)
        {
            this.Id = id;
            this.Titel = titel;
            this.Inhoud = inhoud;
            this.TypeId = typeId;
            this.Tag = tag;
            this.GoedgekeurdDoor = goedgekeurdDoor;
            this.ImageFile = imageFile;
            this.Uitgelicht = false;
        }


        public Post(int id, string titel, string inhoud, int typeId, Tag tag, int goedgekeurdDoor)
        {
            this.Id = id;
            this.Titel = titel;
            this.Inhoud = inhoud;
            this.TypeId = typeId;
            this.Tag = tag;
            this.Uitgelicht = false;
        }

        public Post()
        {
            this.Uitgelicht = false;
        }
    }
}
