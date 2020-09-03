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
                if (context.Kunde.Any())
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
                context.SaveChanges();
            }
        }
    }
}
