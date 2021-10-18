using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Db
{
    public static class SeedDbProvider
    {
        public static void Seed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            context.Database.Migrate();

            if (context.Platforms.Any())
            {
                Console.WriteLine("We already have data...");
            }
            else
            {
                Console.WriteLine("Seeding data...");
                context.Platforms.AddRange(
                    new Platform() {
                        Name = "Dot net",
                        Publisher = "Microsoft",
                        Cost = "free",
                    }, 
                    new Platform() {
                        Name = "Dot net 1",
                        Publisher = "Microsoft",
                        Cost = "free",
                    },
                    new Platform() {
                        Name = "Dot net 2",
                        Publisher = "Microsoft",
                        Cost = "free",
                    }
                );

                context.SaveChanges();
            }
        }
    }
}