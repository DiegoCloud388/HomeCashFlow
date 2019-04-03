using CashPrototype_v2._2.Web.Api.Infrastructure.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashPrototype_v2._2.Web.Api.Infrastructure.Models
{
    public class AuthenticationDbContext : IdentityDbContext<User, UserRole, int>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .Property(r => r.EmailConfirmed)
                .HasConversion(new BoolToZeroOneConverter<Int16>());

            builder.Entity<User>()
               .Property(r => r.LockoutEnabled)
               .HasConversion(new BoolToZeroOneConverter<Int16>());

            builder.Entity<User>()
               .Property(r => r.PhoneNumberConfirmed)
               .HasConversion(new BoolToZeroOneConverter<Int16>());

            builder.Entity<User>()
               .Property(r => r.TwoFactorEnabled)
               .HasConversion(new BoolToZeroOneConverter<Int16>());
        }
    }
}
