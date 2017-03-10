using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Leisurebooker.Business.Domain
{
    public class Company : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string VATNumber { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }


        public string Box { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public ICollection<Branch> Branches { get; set; }

    }
}
