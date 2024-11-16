﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementAPI.Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(fk => fk.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.Name)
                .IsRequired();
        }
    }
}
