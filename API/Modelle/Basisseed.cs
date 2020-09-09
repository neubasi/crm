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
                if (context.Kunde.Any() && context.Bestellung.Any() && context.Artikel.Any())
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

                context.Bestellung.AddRange(
                   new Bestellung
                   {
                       Text = "Meine erste Bestellung.",
                       FK_Artikel = 1
                   },

                   new Bestellung
                   {
                       Text = "Meine zweite Bestellung.",
                       FK_Artikel = 1
                   },

                   new Bestellung
                   {
                       Text = "Meine dritte Bestellung.",
                       FK_Artikel = 2
                   },

                   new Bestellung
                   {
                       Text = "Meine vierte Bestellung.",
                       FK_Artikel = 3
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

                context.SaveChanges();
            }
        }
    }
}
