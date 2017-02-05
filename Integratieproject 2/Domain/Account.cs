using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leisurebooker.Business.Domain
{
    public class Account : Entity
    {
        public string Email { get; set; }
        public string Secret { get; set; }
    }
}
