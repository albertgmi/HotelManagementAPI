using HotelManagementAPI.Entities;

namespace HotelManagementAPI.Seeders
{
    public interface IHotelSeeder
    {
        void Seed(HotelDbContext _dbContext);
    }
}
