using AutoMapper;
using HotelManagementAPI.Authorizations;
using HotelManagementAPI.Authorizations.HotelAuthorizations;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Exceptions;
using HotelManagementAPI.Models.HotelModels;
using HotelManagementAPI.Models.UserModels;
using HotelManagementAPI.Services.FileService;
using HotelManagementAPI.Services.ReportServiceFolder;
using HotelManagementAPI.Services.UserServiceFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace HotelManagementAPI.Services.HotelServiceFolder
{
    public class HotelService : IHotelService
    {
        private readonly HotelDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        private readonly IReportService _reportService;
        private readonly IFileService _fileService;

        public HotelService(HotelDbContext dbContext, IMapper mapper, IUserContextService userContextService,
            IAuthorizationService authorizationService, IReportService reportService, IFileService fileService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
            _authorizationService = authorizationService;
            _reportService = reportService;
            _fileService = fileService;
        }

        public List<HotelDto> GetAll()
        {
            var hotels = _dbContext
                .Hotels
                .Include(h=>h.Address)
                .Include(h=>h.Rooms)
                .ThenInclude(r=>r.Reservations)
                .ToList();
            if (hotels is null)
                throw new NotFoundException("Hotel not found");

            var hotelDto = _mapper.Map<List<HotelDto>>(hotels);
            return hotelDto;
        }
        public HotelDto GetById(int hotelId)
        {
            var hotel = GetHotelById(hotelId);

            var hotelDto = _mapper.Map<HotelDto>(hotel);
            return hotelDto;
        }
        public int Create(CreateHotelDto dto)
        {
            var hotel = _mapper.Map<Hotel>(dto);
            var hotelId = hotel.Id;

            hotel.CreatedById = (int)_userContextService.GetUserId;

            _dbContext.Hotels.Add(hotel);
            _dbContext.SaveChanges();

            return hotelId;
        }
        public void Update(int hotelId, UpdateHotelDto dto)
        {
            var hotel = GetOnlyHotelById(hotelId);

            var user = _userContextService.User;

            AuthorizedTo(hotel, user, ResourceOperation.Update);

            hotel.Name = dto.Name;
            hotel.Description = dto.Description;
            _dbContext.SaveChanges();
        }
        public void Delete(int hotelId)
        {
            var hotel = GetOnlyHotelById(hotelId);

            var user = _userContextService.User;

            AuthorizedTo(hotel, user, ResourceOperation.Delete);

            _dbContext.Hotels.Remove(hotel);
            _dbContext.SaveChanges();
        }
        public UserDto GetOwner(int hotelId)
        {
            var hotel = GetOnlyHotelById(hotelId);

            var managerId = hotel.CreatedById;
            var manager = _dbContext
                .Users
                .FirstOrDefault(x=>x.Id== managerId);
            if (manager is null)
                throw new NotFoundException("Hotel manager not found");
            var managerDto = _mapper.Map<UserDto>(manager);
            return managerDto;
        }
        public void AddRating(int hotelId, decimal rating)
        {
            if (rating < 1 || rating > 5)
                throw new NotInRangeException("Rating has to be in range 1-5");

            var hotel = GetOnlyHotelById(hotelId);

            if (hotel.NumberOfRatings == 0)
            {
                hotel.Rating = rating;
                hotel.NumberOfRatings = 1;
            }
            else
            {
                hotel.NumberOfRatings++;
                hotel.Rating = (hotel.Rating * (hotel.NumberOfRatings - 1) + rating) / hotel.NumberOfRatings;
            }
            _dbContext.SaveChanges();
        }
        public byte[] GenerateReport(int hotelId, DateTime startDate, DateTime endDate)
        {
            var hotel = GetHotelById(hotelId);
            var user = _userContextService.User;
            AuthorizedTo(hotel, user, ResourceOperation.GetReport);

            QuestPDF.Settings.License = LicenseType.Community;
            var report = _reportService.GenerateFullReport(hotel, startDate, endDate);
            var pdf = report.GeneratePdf();
            return pdf;
        }
        public string UploadHotelImage(int hotelId,IFormFile file)
        {
            var hotel = _dbContext
                .Hotels
                .FirstOrDefault(x => x.Id == hotelId);
            if (hotel is null)
                throw new NotFoundException("Hotel not found");

            var url = _fileService.UploadImage(hotelId, null, file);
            _fileService.AddImageToHotel(hotelId, url);
            return url;
        }  
        public void DeleteHotelImage(int imageId)
        {
            var image = _dbContext
                .Images
                .FirstOrDefault(x => x.Id == imageId);
            if (image is null)
                throw new NotFoundException("Image not found");
            var url = image.Url;
            _fileService.DeleteImage(url);
            _fileService.DeleteImageFromDb(imageId);
        }
        private void AuthorizedTo(Hotel hotel, ClaimsPrincipal user, ResourceOperation operation)
        {
            var authorizationResult = _authorizationService.AuthorizeAsync(user, hotel,
                new CreatedHotelRequirement(operation)).Result;
            if (!authorizationResult.Succeeded)
                throw new ForbidException("Authorization failed");
        }
        private Hotel GetHotelById(int hotelId)
        {
            var hotel = _dbContext
                .Hotels
                .Include(x=>x.Address)
                .Include(x => x.Rooms)
                .ThenInclude(x => x.Reservations)
                .FirstOrDefault(x => x.Id == hotelId);
            if (hotel is null)
                throw new NotFoundException("Hotel not found");
            return hotel;
        }
        private Hotel GetOnlyHotelById(int hotelId)
        {
            var hotel = _dbContext
                .Hotels
                .FirstOrDefault(x => x.Id == hotelId);
            if (hotel is null)
                throw new NotFoundException("Hotel not found");
            return hotel;
        }
    }
}
