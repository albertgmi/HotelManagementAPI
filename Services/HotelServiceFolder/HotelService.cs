using AutoMapper;
using Bogus;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Exceptions;
using HotelManagementAPI.Models.HotelModels;
using HotelManagementAPI.Services.UserServiceFolder;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Services.HotelServiceFolder
{
    public class HotelService : IHotelService
    {
        private readonly HotelDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        Faker faker = new Faker();

        public HotelService(HotelDbContext dbContext, IMapper mapper, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
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
        public int Create(CreateHotelDto dto)
        {
            var hotel = _mapper.Map<Hotel>(dto);
            var hotelId = hotel.Id;

            // To be fixed
            var users = _dbContext.Users.ToList();
            var userId = users[faker.Random.Int(1, users.Count() - 1)].Id;
            hotel.ManagedById = userId;

            _dbContext.Hotels.Add(hotel);
            _dbContext.SaveChanges();

            return hotelId;
        }
        public void Update(int id, UpdateHotelDto dto)
        {
            var hotel = _dbContext
                .Hotels
                .FirstOrDefault(x=>x.Id==id);
            if (hotel is null)
                throw new NotFoundException("Hotel not found");

            hotel.Name = dto.Name;
            hotel.Description = dto.Description;
            _dbContext.SaveChanges();
        }
    }
}
