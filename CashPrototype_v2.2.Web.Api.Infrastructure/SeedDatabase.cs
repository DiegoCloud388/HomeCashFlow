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

        private static void SeedUsers(AuthenticationDbContext dbContext)
        {
            dbContext.Users.Add(
                new Entities.Users.User
                {
                    UserName = "Test",
                    UserLastName = "Novotny",
                    Email = "alfabeta@email.cz",
                    PasswordHash = "Abcd1234@"                     
                });

            dbContext.SaveChanges();
        }
    }
}
