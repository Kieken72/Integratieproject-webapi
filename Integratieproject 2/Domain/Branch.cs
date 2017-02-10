using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Leisurebooker.Business.Domain
{
    //Makkelijk zoekbaar op adress!!! Index? + Makkelijk zoekbaar van plek vrij!

    public class Branch : Entity
    {
        [Required]
        public string Name { get; set; }
        //ADRESS
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string PhoneNumber { get; set; }
        //public string Picture { get; set; }
        [Required]
        public string Email { get; set; }

        public int CompanyId { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<OperationHours> OpeningHours { get; set; }
        public ICollection<AdditionalInfo> AdditionalInfos { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Account> Favorites { get; set; }

    }
}
