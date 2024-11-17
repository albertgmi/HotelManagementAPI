namespace HotelManagementAPI.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        // Relations
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
