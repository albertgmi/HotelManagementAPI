using HotelManagementAPI.Entities;
using HotelManagementAPI.Models.RoomModels;

namespace HotelManagementAPI.Services.RoomServiceFolder
{
    public interface IRoomService
    {
        List<RoomDto> GetAll(int hotelId);
        RoomDto GetById(int hotelId, int roomId);
    }
}
