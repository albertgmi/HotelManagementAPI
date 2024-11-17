using AutoMapper;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Models.HotelModels;
using HotelManagementAPI.Models.RoomModels;

namespace HotelManagementAPI.Profiles
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile()
        {
            CreateMap<Hotel, HotelDto>()
                .ForMember(dto => dto.City, h => h.MapFrom(x => x.Address.City))
                .ForMember(dto => dto.Street, h => h.MapFrom(x => x.Address.Street))
                .ForMember(dto => dto.PostalCode, h => h.MapFrom(x => x.Address.PostalCode));
            CreateMap<CreateHotelDto, Hotel>()
                .ForMember(r => r.Address, dto => dto.MapFrom(x => new Address()
                { City = x.City, Street = x.Street, PostalCode = x.PostalCode }));
            CreateMap<Room, RoomDto>();
        }
    }
}
