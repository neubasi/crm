using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelle
{
    public class Kunde: Basismodell
    {
       // [Required]
        public string Name { get; set; }

        [InverseProperty(nameof(Bestellung.KundeNavigation))]
        public IEnumerable<Bestellung> Bestellungen = new List<Bestellung>();
    }
}
