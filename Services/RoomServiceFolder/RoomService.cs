using AutoMapper;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Exceptions;
using HotelManagementAPI.Models.RoomModels;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotelManagementAPI.Services.RoomServiceFolder
{
    public class RoomService : IRoomService
    {
        private readonly HotelDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoomService(HotelDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<RoomDto> GetAll(int hotelId)
        {
            var hotel = GetHotelWithRooms(hotelId);

            var rooms = hotel
                .Rooms
                .ToList();

            if (rooms is null)
                throw new NotFoundException($"Rooms not found in hotel with id {hotelId}");

            var roomsDto = _mapper.Map<List<RoomDto>>(rooms);
            
            return roomsDto;
        }
        public RoomDto GetById(int hotelId, int roomId)
        {
            var hotel = GetHotelWithRooms(hotelId);

            var room = hotel
                .Rooms
                .FirstOrDefault(x => x.Id == roomId);

            if (room is null)
                throw new NotFoundException($"Room with id {roomId} was not found in hotel with id {hotelId}");

            var roomDto = _mapper.Map<RoomDto>(room);

            return roomDto;
        }
        private Hotel GetHotelWithRooms(int hotelId)
        {
            var hotel = _dbContext
                .Hotels
                .Include(x => x.Rooms)
                .ThenInclude(r=>r.Reservations)
                .FirstOrDefault(x => x.Id == hotelId);
            if (hotel is null)
                throw new NotFoundException("Hotel not found");
            return hotel;
        }
    }
}
