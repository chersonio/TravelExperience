using AutoMapper;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DTO.Dtos;

namespace TravelExperience.API.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Accommodation, AccommodationDto>();
            Mapper.CreateMap<AccommodationDto, Accommodation>();

            Mapper.CreateMap<Booking, BookingDto>();
            Mapper.CreateMap<BookingDto, Booking>();

            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<LocationDto, Location>();

            Mapper.CreateMap<Utility, UtilityDto>();
            Mapper.CreateMap<UtilityDto, Utility>();

            //Mapper.CreateMap<ApplicationUser, UserDto>();
            //Mapper.CreateMap<UserDto, ApplicationUser>();
        }
    }
}