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
        public int TypeId { get; set; }

        public Event()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
