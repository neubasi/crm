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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use the shadow property as a foreign key
                        
            modelBuilder.Entity<Bestellung>()
           .HasOne<Artikel>()
           .WithMany()
           .HasForeignKey(p => p.FK_Artikel);


            modelBuilder.Entity<Bestellung>()
           .HasOne<Kunde>()
           .WithMany()
           .HasForeignKey(p => p.FK_Kunde);
        }


        public Basiscontext(DbContextOptions<Basiscontext> options)
            : base(options)
        {
        }

        public DbSet<Bestellung> Bestellung { get; set; }
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<Artikel> Artikel { get; set; }


    }
}
