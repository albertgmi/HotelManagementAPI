using AutoMapper;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Exceptions;
using HotelManagementAPI.Models.ReportModels;
using HotelManagementAPI.Services.UserServiceFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Services.ReportServiceFolder
{
    public class ReportService : IReportService
    {
        private readonly HotelDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public ReportService(HotelDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }
        public OccupancyReport GenerateOccupancyRaport(Hotel hotel, DateTime startDate, DateTime endDate)
        {
            var hotelRoomIds = hotel
                .Rooms
                .Select(room => room.Id)
                .ToList();

            var totalRooms = hotel.Rooms.ToList().Count;

            var occupiedRooms = _dbContext
                .Reservations
                .Where(reservation => reservation.CheckInDate <= endDate
                                      && reservation.CheckOutDate >= startDate
                                      && hotelRoomIds.Contains(reservation.RoomId))
                .Select(reservation => reservation.RoomId)
                .Distinct()
                .ToList()
                .Count;

            var occupancyRate = (double)occupiedRooms / totalRooms * 100;

            return new OccupancyReport
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalRooms = totalRooms,
                OccupiedRooms = occupiedRooms,
                OccupancyRate = $"{occupancyRate:F2}%"
            };
        }
    }
}
