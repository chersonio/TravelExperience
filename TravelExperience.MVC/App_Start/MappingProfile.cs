using AutoMapper;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DTO.AccommodationDto;

namespace TravelExperience.MVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Accommodation, AccommodationDto>();
            Mapper.CreateMap<AccommodationDto, Accommodation>();
        }
    }
}