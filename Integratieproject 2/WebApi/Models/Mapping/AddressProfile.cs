using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            this.CreateMap<Adress, AdressDto>();
            this.CreateMap<AdressDto, Adress>();
        }
    }
}