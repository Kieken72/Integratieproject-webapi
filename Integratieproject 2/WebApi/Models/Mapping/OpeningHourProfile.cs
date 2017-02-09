using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class OpeningHourProfile : Profile
    {
        public OpeningHourProfile()
        {
            this.CreateMap<OperationHours, OpeningHourDto>();
            this.CreateMap<OpeningHourDto, OperationHours>();
        }
    }
}