using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            this.CreateMap<Room, RoomDto>();
            this.CreateMap<RoomDto, Room>();
        }
    }
}