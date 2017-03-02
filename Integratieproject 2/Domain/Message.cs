using System;

namespace Leisurebooker.Business.Domain
{
    public class Message : Entity
    {
        public int ReservationId { get; set; }
        public int BranchId { get; set; }
        public string UserId { get; set; }


        public bool Read { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int? EventId { get; set; }
        public MessageEvent Event { get; set; }

        public Message()
        {
            DateTime = DateTime.Now;
            Read = false;
        }
    }
}