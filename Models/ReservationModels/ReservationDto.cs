namespace HotelManagementAPI.Models.ReservationModels
{
    public class ReservationDto
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
    }
}
