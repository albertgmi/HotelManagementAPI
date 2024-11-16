using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementAPI.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(r => r.FirstName)
                .IsRequired();
            builder.Property(r => r.LastName)
                .IsRequired();
            builder.Property(r => r.Email)
                .IsRequired();
            builder.Property(r => r.PasswordHash)
                .IsRequired();
        }
    }
}
