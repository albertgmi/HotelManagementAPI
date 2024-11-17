using HotelManagementAPI.Models.HotelModels;

namespace HotelManagementAPI.Services.HotelServiceFolder
{
    public interface IHotelService
    {
        List<HotelDto> GetAll();
        HotelDto GetById(int id);
        int Create(CreateHotelDto dto);
        void Update(int id, UpdateHotelDto dto);
    }
}
