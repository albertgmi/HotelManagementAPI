using HotelManagementAPI.Entities;

namespace HotelManagementAPI.Services.EmailServiceFolder
{
    public interface IEmailService
    {
        Task SendEmailAsync(Hotel hotel, Room room, User user, Reservation reservation);
    }
}
