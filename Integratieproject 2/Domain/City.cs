using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leisurebooker.Business.Domain
{
    public class City : Entity
    {
        public string PostalCode { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }

        public int? HeadCityId { get; set; }
        public City HeadCity { get; set; }

        public ICollection<City> SubCities { get; set; }

        public ICollection<Branch> Branches { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
