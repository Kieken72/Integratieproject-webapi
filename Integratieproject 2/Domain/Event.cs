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
        //Toadd
    }

    public enum EventType
    {
        NewReservation,
        ModifyReservation,
        CancelReservation,
        NewMessage,
        NewReview
        
    }
}
