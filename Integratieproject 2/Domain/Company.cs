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
        
        public Adress Adress { get; set; }

        public ICollection<Branch> Branches { get; set; }

    }
}
