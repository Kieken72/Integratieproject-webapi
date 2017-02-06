using System;

namespace Leisurebooker.Business.Domain
{
    public class Message : Entity
    {
        //Aan welke reservatie hangt dit,
        public int ReservationId { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }

        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}