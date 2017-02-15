using System.Collections.Generic;
using Leisurebooker.Business.Domain;

namespace WebApi.Models.Dto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
    }

    public class FullCityDto
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }

        public CityDto HeadCity { get; set; }
        public ICollection<CityDto> SubCities { get; set; }
    }
}