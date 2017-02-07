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

        public AdressDto Adress { get; set; }

        //public ICollection<BranchDto> Branches { get; set; }
    }
}