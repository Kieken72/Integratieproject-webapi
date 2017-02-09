using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class OpeningHourProfile : Profile
    {
        public OpeningHourProfile()
        {
            this.CreateMap<OperationHours, OperationHoursDto>();
            this.CreateMap<OperationHoursDto, OperationHours>();
        }
    }
}