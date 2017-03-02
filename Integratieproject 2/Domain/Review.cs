using System;

namespace Leisurebooker.Business.Domain
{
    public class Review : Entity
    {
        public bool Result { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public bool Public { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int? EventId { get; set; }
        public ReviewEvent Event { get; set; }
        public int BranchId { get; set; }
        public string UserId { get; set; }
        public virtual Account User { get; set; }

        public Review()
        {
            DateTime= DateTime.Now;
            
        }
    }
}