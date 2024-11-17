using AutoMapper;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Exceptions;
using HotelManagementAPI.Models.HotelModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Services.HotelServiceFolder
{
    public class HotelService : IHotelService
    {
        private readonly HotelDbContext _dbContext;
        private readonly IMapper _mapper;

        public HotelService(HotelDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<HotelDto> GetAll()
        {
            var hotels = _dbContext
                .Hotels
                .Include(h=>h.Address)
                .Include(h=>h.Rooms)
                .ToList();
            if (hotels is null)
                throw new NotFoundException("Hotel not found");
            var hotelDto = _mapper.Map<List<HotelDto>>(hotels);
            return hotelDto;
        }
        public HotelDto GetById(int id)
        {
            var hotel = _dbContext
                .Hotels
                .Include(h => h.Address)
                .Include(h => h.Rooms)
                .FirstOrDefault(h => h.Id == id);
            if (hotel is null)
                throw new NotFoundException("Hotel not found");
            var hotelDto = _mapper.Map<HotelDto>(hotel);
            return hotelDto;
        }
    }
}
