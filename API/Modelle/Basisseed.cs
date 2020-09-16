using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelle
{
    public class Basisseed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Basiscontext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Basiscontext>>()))
            {
                
                // Look for any movies.
                if (context.Kunde.Any() && context.Artikel.Any())
                {
                    return;   // DB has been seeded
                }



                

                context.Kunde.AddRange(
                    new Kunde
                    {
                        Name = "When Harry Met Sally"
                    },

                    new Kunde
                    {
                        Name = "Ghostbusters "
                    },

                    new Kunde
                    {
                        Name = "Ghostbusters 2"
                    },

                    new Kunde
                    {
                        Name = "Rio Bravo"
                    }
                );

        
          

               
                context.Artikel.AddRange(
                   new Artikel
                   {
                       Name = "Artikel 1",
                       Einheit = "Stück",
                       Preis = 25
                   },

                   new Artikel
                   {
                       Name = "Artikel 2",
                       Einheit = "Stück",
                       Preis = 21
                   },

                   new Artikel
                   {
                       Name = "Artikel 3",
                       Einheit = "Stück",
                       Preis = 12
                   },

                   new Artikel
                   {
                       Name = "Artikel 4",
                       Einheit = "Palette",
                       Preis = 20
                   }
               );

             

                /*
                context.Bestellung.AddRange(
                  new Bestellung
                  {
                      Text = "Meine erste Bestellung.",
                      ArtikelId = 1,
                      KundeId = 1,
                      Menge = 1,
                      Betrag = 99
                  },

                  new Bestellung
                  {
                      Text = "Meine zweite Bestellung.",
                      ArtikelId = 1,
                      KundeId = 1,
                      Menge = 10,
                      Betrag = 99
                  },

                  new Bestellung
                  {
                      Text = "Meine dritte Bestellung.",
                      ArtikelId = 2,
                      KundeId = 1,
                      Menge = 5,
                      Betrag = 99
                  },

                  new Bestellung
                  {
                      Text = "Meine vierte Bestellung.",
                      ArtikelId = 3,
                      KundeId = 1,
                      Menge = 20,
                      Betrag = 99
                  }
              );*/



                context.SaveChanges();

               
            }
        }
    }
}
