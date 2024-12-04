using HotelManagementAPI.Entities;

namespace HotelManagementAPI.Services.UpdateServiceFolder
{
    public interface IUpdateService
    {
        void Update(HotelDbContext _dbContext);
    }
}
