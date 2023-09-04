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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");


            builder.HasData(new AppUserRole
            {
                UserId= Guid.Parse("6C7BF599-963F-47F3-B488-0218EA50FBEC"),
                RoleId= Guid.Parse("43825A01-65A3-43AD-A6D1-8C0A70BDE378"),
            },
            new AppUserRole
            {
                UserId= Guid.Parse("71829B03-40EE-42D5-A62E-2827D34A02FA"),
                RoleId= Guid.Parse("EBF0EF6F-1D52-4197-96C0-0C48FBAC76AD"),
            }
            );
        }
    }
}
