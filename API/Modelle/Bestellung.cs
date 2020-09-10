using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelle
{
    public class Bestellung: Basismodell
    {
       // [Required]
        public string Text { get; set; }

       // [Required]
        public long FK_Artikel { get; set; }

        public long FK_Kunde { get; set; }
    }
}
