﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementAPI.Entities.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasOne(r=>r.Reservation)
                .WithOne(r=>r.Room)
                .HasForeignKey<Room>(fk=>fk.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(r => r.Name)
                .IsRequired();
            builder.Property(r => r.Capacity)
                .IsRequired();
            builder.Property(r => r.PricePerNight)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
        }
    }
}
