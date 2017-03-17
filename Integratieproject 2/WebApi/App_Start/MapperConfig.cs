using AutoMapper;
using WebApi.Models.Mapping;

namespace WebApi
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<CompanyProfile>();
                cfg.AddProfile<CityProfile>();
                cfg.AddProfile<BranchProfile>();
                cfg.AddProfile<OpeningHourProfile>();
                cfg.AddProfile<AdditionalInfoProfile>();
                cfg.AddProfile<MessageProfile>();
                cfg.AddProfile<ReservationProfile>();
                cfg.AddProfile<ReviewProfile>();
                cfg.AddProfile<SpaceProfile>();
                cfg.AddProfile<RoomProfile>();
            });
        }
    }
}