using HotelManagementAPI.Models.HotelModels;
using HotelManagementAPI.Models.ReportModels;
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
        UserDto GetOwner(int hotelId);
        void AddRating(int hotelId, decimal rating);
        OccupancyReport GenerateReport(int id, DateTime startDate, DateTime endDate);
    }
}
