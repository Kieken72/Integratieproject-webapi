using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            this.CreateMap<Reservation, ReservationDto>();
            this.CreateMap<ReservationDto, Reservation>();
        }
    }
}