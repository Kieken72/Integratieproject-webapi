using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leisurebooker.Business.Domain
{
    public class Account : IdentityUser
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }

        public ICollection<Branch> Favorites { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reservation> Reservations { get; set; }



    }
}
