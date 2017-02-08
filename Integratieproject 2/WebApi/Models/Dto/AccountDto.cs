using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }

        public string Secret { get; set; }

        //public ICollection<BranchDto> Favorites { get; set; }
        //public ICollection<MessageDto> Messages { get; set; }
        //public ICollection<ReviewDto> Reviews { get; set; }
        //public ICollection<ReservationDto> Reservations { get; set; }
    }
}