using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leisurebooker.Business.Domain
{
    public class AuthAccount : IdentityUser
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }



    }
}
