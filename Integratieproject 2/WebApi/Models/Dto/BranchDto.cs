using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Dto
{
    public class BranchDto
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public int CityId { get; set; }
        public CityDto City { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int CompanyId { get; set; }

        //public ICollection<Room> Rooms { get; set; }
        public ICollection<OpeningHourDto> OpeningHours { get; set; }
        //public ICollection<AdditionalInfo> AdditionalInfos { get; set; }

        //public ICollection<Message> Messages { get; set; }
        //public ICollection<Reservation> Reservations { get; set; }
    }
}