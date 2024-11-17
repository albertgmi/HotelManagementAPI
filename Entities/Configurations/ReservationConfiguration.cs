using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementAPI.Entities.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(r => r.MadeBy)
                .WithMany(u => u.Reservations)
                .HasForeignKey(fk => fk.MadeById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.CheckInDate)
                .IsRequired();
            builder.Property(r => r.CheckOutDate)
                .IsRequired();
            builder.Property(r => r.ReservationPrice)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
        }
    }
}
