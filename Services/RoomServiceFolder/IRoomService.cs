using HotelManagementAPI.Entities;
using HotelManagementAPI.Models.RoomModels;

namespace HotelManagementAPI.Services.RoomServiceFolder
{
    public interface IRoomService
    {
        List<RoomDto> GetAll(int hotelId);
        RoomDto GetById(int hotelId, int roomId);
        int CreateRoom(int hotelId, CreateRoomDto dto);
        void UpdateRoom(int hotelId, int roomId, UpdateRoomDto dto);
        void DeleteRoomById(int hotelId, int roomId);
        void DeleteAllRooms(int hotelId);
        List<RoomDto> GetAvailableRooms(int hotelId, DateTime from, DateTime? to);
        string UploadRoomImage(int hotelId, int roomId, IFormFile file);
    }
}
