using HotelManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Services.UpdateServiceFolder
{
    public class UpdateService : IUpdateService
    {
        public void Update(HotelDbContext _dbContext)
        {
            var reservations = _dbContext
                    .Reservations
                    .Include(r => r.Room)
                    .Where(r => r.CheckInDate <= DateTime.Now && r.CheckOutDate > DateTime.Now)
                    .ToList();
            foreach (var reservation in reservations)
            {
                if (reservation.Room.IsAvailable)
                    reservation.Room.IsAvailable = false;
            }
            _dbContext.SaveChanges();
        }
    }
}
