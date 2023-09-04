using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class RoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("AspNetRoles");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            builder.HasData(new AppRole
            {
                Id = Guid.Parse("43825A01-65A3-43AD-A6D1-8C0A70BDE378"),
                Name="Superadmin",
                NormalizedName="SUPERADMIN",
                ConcurrencyStamp=Guid.NewGuid().ToString()   //İşlem çakışmalarını engeller.
            },
            new AppRole
            {
                Id=Guid.Parse("EBF0EF6F-1D52-4197-96C0-0C48FBAC76AD"),
                Name="Admin",
                NormalizedName="ADMIN",
                ConcurrencyStamp=Guid.NewGuid().ToString() 
            },
            new AppRole
            {
                Id=Guid.Parse("8AD28833-513A-4101-A75D-21B871D22562"),
                Name="User",
                NormalizedName="USER",
                ConcurrencyStamp=Guid.NewGuid().ToString()
            });
        }
    }
}
