namespace HotelManagementAPI.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal ReservationPrice { get; set; }
        public string Status { get; set; }
        
        // Relations
        public int MadeById { get; set; }
        public User MadeBy { get; set; }
        public Room Room { get; set; }
    }
}
