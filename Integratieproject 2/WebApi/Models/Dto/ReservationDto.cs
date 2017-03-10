using System;
using System.Collections.Generic;

namespace WebApi.Models.Dto
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int AmountOfPersons { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int SpaceId { get; set; }
        public int BranchId { get; set; }
        public string AccountId { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
        public ReviewDto Review { get; set; }
        public FullAccountDto User { get; set; }
        public bool Cancelled { get; set; }
        public bool Arrived { get; set; }
        public bool NoShow { get; set; }
        public bool Passed { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public class NewReservationDto
    {
        public int BranchId { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
    }
}