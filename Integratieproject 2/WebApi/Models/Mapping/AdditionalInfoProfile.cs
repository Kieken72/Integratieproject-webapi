using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class AdditionalInfoProfile : Profile
    {
        public AdditionalInfoProfile()
        {
            this.CreateMap<AdditionalInfo, AdditionalInfoDto>();
            this.CreateMap<AdditionalInfoDto, AdditionalInfo>();
        }

    }
}
