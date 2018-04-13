using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(
                serviceProvider.GetRequiredService<DbContextOptions<WebApplication1Context>>()))
            {
                //Look for any locations
                if (context.Destination.Any())
                {
                    //System.Console.WriteLine("Database has been seeded.")
                    return; // DB has already been seeded
                }

                context.Destination.AddRange(
                    new Destination
                    {
                        Location = "Hoi An",
                        VisitDate = DateTime.Parse("2018-4-11"),
                        Description = "Beach and Food",
                        ExcursionCost = 200
                    },
                    new Destination
                    {
                        Location = "Ba Na Hills",
                        VisitDate = DateTime.Parse("2018-4-12"),
                        Description = "Castle in the sky and Food",
                        ExcursionCost = 200
                    },
                    new Destination
                    {
                        Location = "Hue",
                        VisitDate = DateTime.Parse("2008-6-14"),
                        Description = "Family",
                        ExcursionCost = 200
                    },
                    new Destination
                    {
                        Location = "Mekong",
                        VisitDate = DateTime.Parse("2008-6-15"),
                        Description = "Would like to go",
                        ExcursionCost = 200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
