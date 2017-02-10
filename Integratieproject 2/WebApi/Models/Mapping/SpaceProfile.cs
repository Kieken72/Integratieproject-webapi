using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class SpaceProfile : Profile
    {
        public SpaceProfile()
        {
            this.CreateMap<Space, SpaceDto>();
            this.CreateMap<SpaceDto, Space>();
        }
    }
}