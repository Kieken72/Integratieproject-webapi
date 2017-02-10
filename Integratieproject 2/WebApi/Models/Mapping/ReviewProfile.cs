using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            this.CreateMap<Review, ReviewDto>();
            this.CreateMap<ReviewDto, Review>();
        }
    }
}