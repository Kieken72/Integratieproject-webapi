using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leisurebooker.Business.Domain
{
    public class Event : Entity
    {
        public EventType EventType { get; set; }
        public DateTime CreatedOn { get; set; }
        public int BranchId { get; set; }

        public Event()
        {
            CreatedOn = DateTime.Now;
        }
    }

    public class ReservationEvent : Event
    {
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }

    public class MessageEvent : Event
    {
        public int? MessageId { get; set; }
        public Message Message { get; set; }
    }

    public class ReviewEvent : Event
    {
        public int? ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
