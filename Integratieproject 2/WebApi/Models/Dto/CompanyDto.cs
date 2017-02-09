using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Dto
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public string VATNumber { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public virtual CityDto City { get; set; }
        public ICollection<BranchDto> Branches { get; set; }
    }

}