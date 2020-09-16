using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelle
{
    public class Bestellung: Basismodell
    {
       // [Required]
        public string Text { get; set; }

        public int Menge { get; set; }

        [Required]
        public long ArtikelId { get; set; }

        [ForeignKey(nameof(ArtikelId))]
        public virtual Artikel ArtikelNavigation { get; set; }

       
        [Required]
        public long KundeId { get; set; }

        [ForeignKey(nameof(KundeId))]
        public virtual Kunde KundeNavigation { get; set; }

        [Required]
        public int Betrag { get; set; }


        public int calculateTotal(int Menge, int Preis)
        {
            return Menge * Preis;
        }

        //get => Menge * ArtikelNavigation.Preis;



    }

    public class BestellungDTO : Basismodell
    {
        // [Required]
        public string Text { get; set; }

        public int Menge { get; set; }

        [Required]
        public long ArtikelId { get; set; }

        public string ArtikelText { get; set; }

        public decimal Betrag { get; set; }

        [Required]
        public long KundeId { get; set; }

        public string KundeText { get; set; }




    }

}
