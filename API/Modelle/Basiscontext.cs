using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Modelle;

namespace API.Modelle
{
    public class Basiscontext : DbContext
    {
        
      


        public Basiscontext(DbContextOptions<Basiscontext> options)
            : base(options)
        {
        }
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Bestellung> Bestellung { get; set; }
  



    }
}
