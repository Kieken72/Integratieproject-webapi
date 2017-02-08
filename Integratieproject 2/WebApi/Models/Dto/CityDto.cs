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

        //public int? HeadCityId { get; set; }
        //public ICollection<CityDto> SubCities { get; set; }
    }
}