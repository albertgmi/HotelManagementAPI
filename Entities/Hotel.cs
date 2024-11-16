
namespace HotelManagementAPI.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Rating { get; set; }

        // Relations
        public Address Address { get; set; }
        public int ManagedById { get; set; }
        public User ManagedBy { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
