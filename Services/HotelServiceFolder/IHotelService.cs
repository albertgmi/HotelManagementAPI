using HotelManagementAPI.Models.HotelModels;
using HotelManagementAPI.Models.UserModels;
using QuestPDF.Fluent;

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
        byte[] GenerateReport(int hotelId, DateTime startDate, DateTime endDate);
    }
}
