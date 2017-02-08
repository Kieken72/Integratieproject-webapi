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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }

        public string Secret { get; set; }

        public ICollection<Branch> Favorites { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reservation> Reservations { get; set; }



    }
}
