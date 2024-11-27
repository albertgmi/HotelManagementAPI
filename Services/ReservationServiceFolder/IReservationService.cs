using HotelManagementAPI.Models.ReservationModels;

namespace HotelManagementAPI.Services.ReservationServiceFolder
{
    public interface IReservationService
    {
        List<ReservationDto> GetAll(int hotelId, int roomId);
        ReservationDto GetById(int hotelId, int roomId, int reservationId);
        int Create(int hotelId, int roomId, CreateReservationDto dto);
        void Delete(int hotelId, int roomId, int reservationId);
        void Update(int hotelId, int roomId, int reservationId, UpdateReservationDto dto);
    }
}
