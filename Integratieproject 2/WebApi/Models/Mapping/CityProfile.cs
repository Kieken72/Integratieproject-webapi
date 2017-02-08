using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            this.CreateMap<City, CityDto>();
            this.CreateMap<CityDto, City>();
        }
    }
}