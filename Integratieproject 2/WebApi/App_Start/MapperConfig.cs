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
                cfg.AddProfile<CompanyProfile>();
                cfg.AddProfile<CityProfile>();
                cfg.AddProfile<BranchProfile>();
                cfg.AddProfile<OpeningHourProfile>();
            });
        }
    }
}