using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leisurebooker.Business.Domain
{
    public class Adress
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Bus { get; set; } //vertaling
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
