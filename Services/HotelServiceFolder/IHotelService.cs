using HotelManagementAPI.Models;
using HotelManagementAPI.Models.HotelModels;
using HotelManagementAPI.Models.UserModels;
using QuestPDF.Fluent;

namespace HotelManagementAPI.Services.HotelServiceFolder
{
    public interface IHotelService
    {
        PagedResult<HotelDto> GetAll(HotelQuery query);
        HotelDto GetById(int id);
        int Create(CreateHotelDto dto);
        void Update(int id, UpdateHotelDto dto);
        void Delete(int id);
        UserDto GetOwner(int hotelId);
        void AddRating(int hotelId, decimal rating);
        byte[] GenerateReport(int hotelId, DateTime startDate, DateTime endDate);
        string UploadHotelImage(int hotelId, IFormFile file);
        void DeleteHotelImage(int imageId);
    }
}
