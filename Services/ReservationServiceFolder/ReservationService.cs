using AutoMapper;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Exceptions;
using HotelManagementAPI.Models.ReservationModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Services.ReservationServiceFolder
{
    public class ReservationService : IReservationService
    {
        private readonly HotelDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReservationService(HotelDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<ReservationDto> GetAll(int hotelId, int roomId)
        {
            var reservations = GetReservationsFromHotelRoom(hotelId, roomId);
            var reservationsDto = _mapper.Map<List<ReservationDto>>(reservations);
            return reservationsDto;
                
        }
        public ReservationDto GetById(int hotelId, int roomId, int reservationId)
        {
            var reservation = GetReservationsFromHotelRoom(hotelId,roomId)
                .FirstOrDefault(x=>x.Id == reservationId);
            var reservationDto = _mapper.Map<ReservationDto>(reservation);
            return reservationDto;
        }
        public int Create(int hotelId, int roomId, CreateReservationDto dto)
        {
            var hotel = _dbContext
                .Hotels
                .Include(h=>h.Rooms)
                .ThenInclude(x=>x.Reservations)
                .FirstOrDefault(x=>x.Id == hotelId);
            if (hotel is null)
                throw new NotFoundException("Hotel was not found");

            var room = hotel
                .Rooms
                .FirstOrDefault(room=>room.Id == roomId);
            if (room is null)
                throw new NotFoundException($"Room with id {roomId} not found in hotel with id {hotelId}.");
            if (dto.CheckInDate < DateTime.Now)
                throw new BadDateException("You can't make reservation in the past.");
            if (dto.CheckInDate >= dto.CheckOutDate)
                throw new BadDateException("Check-out date must be later than check-in date.");

            var isRoomAvailable = !_dbContext.Reservations
            .Any(reservation => reservation.RoomId == roomId &&
                                reservation.CheckInDate < dto.CheckOutDate &&
                                reservation.CheckOutDate > dto.CheckInDate);
            if (!isRoomAvailable)
                throw new RoomNotAvailableException("The room is not available for the selected dates.");

            var days = (dto.CheckOutDate - dto.CheckInDate).Days;
            var totalPrice = room.PricePerNight*days;

            var reservation = new Reservation()
            {
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                MadeById = dto.MadeById,
                RoomId = roomId,
                TotalPrice = totalPrice,
                Status = "Pending"
            };
            var reservationId = reservation.Id;
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
            return reservationId;
        }
        private List<Reservation> GetReservationsFromHotelRoom(int hotelId, int roomId)
        {
            var hotel = _dbContext
                .Hotels
                .Include(x=>x.Rooms)
                .ThenInclude(x=>x.Reservations)
                .FirstOrDefault(x => x.Id == hotelId);
            if(hotel is null)
                throw new NotFoundException($"Hotel was not found");

            var room = hotel
                .Rooms
                .FirstOrDefault(x => x.Id == roomId);
            if (room is null)
                throw new NotFoundException($"Room with id {roomId} was not found in hotel with id {hotelId}");

            var reservations = room
                .Reservations
                .ToList();
            return reservations;
        }
    }
}
