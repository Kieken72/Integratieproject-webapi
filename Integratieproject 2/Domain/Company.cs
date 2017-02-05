using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leisurebooker.Business.Domain
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string VATNumber { get; set; }
        public Adress Adress { get; set; }

        public ICollection<Branch> Branches { get; set; }

    }
}
