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
        public Adress Adress { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public int CompanyId { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<OpeningHour> OpeningHours { get; set; }
        public ICollection<AdditionalInfo> AdditionalInfos { get; set; }

    }
}
