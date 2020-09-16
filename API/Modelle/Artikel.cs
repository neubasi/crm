using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelle
{
    public class Artikel: Basismodell
    {
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Required]
        public string Einheit { get; set; }

        [Required]
        public int Preis { get; set; }

        [InverseProperty(nameof(Bestellung.ArtikelNavigation))]
        public IEnumerable<Bestellung> Bestellungen = new List<Bestellung>();

      
}
}
