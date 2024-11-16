using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementAPI.Entities.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasOne(h => h.Address)
                .WithOne(a => a.Hotel)
                .HasForeignKey<Address>(a => a.HotelId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(h => h.ManagedBy)
                 .WithMany(u => u.Hotels)
                 .HasForeignKey(hfk => hfk.ManagedById)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(x => x.HotelId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Property(h => h.Name)
                .IsRequired();
            builder.Property(h => h.Rating)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
        }
    }
}
