using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            this.CreateMap<Message, MessageDto>();
            this.CreateMap<MessageDto, Message>();
        }
    }
}