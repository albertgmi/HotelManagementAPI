using HotelManagementAPI.Models.HotelModels;
using HotelManagementAPI.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Services.HotelServiceFolder
{
    public interface IHotelService
    {
        List<HotelDto> GetAll();
        HotelDto GetById(int id);
        int Create(CreateHotelDto dto);
        void Update(int id, UpdateHotelDto dto);
        void Delete(int id);
        void AssignManager(int hotelId, int managerId);
        UserDto GetManager(int hotelId);
        void AddRating(int hotelId, decimal rating);
    }
}
