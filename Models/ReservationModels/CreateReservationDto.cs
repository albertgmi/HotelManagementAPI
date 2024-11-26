namespace HotelManagementAPI.Models.ReservationModels
{
    public class CreateReservationDto
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int MadeById { get; set; }
    }
}
