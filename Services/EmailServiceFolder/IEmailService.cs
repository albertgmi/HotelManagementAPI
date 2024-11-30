using HotelManagementAPI.Entities;

namespace HotelManagementAPI.Services.EmailServiceFolder
{
    public interface IEmailService
    {
        void SendEmail(Hotel hotel, Room room, User user, Reservation reservation);
    }
}
