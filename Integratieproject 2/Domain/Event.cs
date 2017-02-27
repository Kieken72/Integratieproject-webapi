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
        public Reservation Reservation { get; set; }
    }

    public class MessageEvent : Event
    {
        public Message Message { get; set; }
    }

    public class ReviewEvent : Event
    {
        public Review Review { get; set; }
    }
}
