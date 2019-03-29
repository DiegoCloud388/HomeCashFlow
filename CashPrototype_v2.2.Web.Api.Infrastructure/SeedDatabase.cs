using CashPrototype_v2._2.Web.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AuthenticationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AuthenticationDbContext>>()))
            {
                SeedUsers(context);
            }
        }

        private static async void SeedUsers(AuthenticationDbContext dbContext)
        {
            await dbContext.Users.AddRangeAsync(
                new Entities.Users.User
                {
                    //UserName = "Test",
                    AccessFailedCount = 3,
                    LockoutEnabled = false,
                    //UserLastName = "Novotny",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    //Email = "alfabeta@email.cz",
                    //PasswordHash = "Abcd1234@"
                });

            await dbContext.SaveChangesAsync();
        }
    }
}
