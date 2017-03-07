﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leisurebooker.Business.Domain
{
    public class Reservation : Entity
    {
        public int AmountOfPersons { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }



        public int SpaceId { get; set; }
        public int BranchId { get; set; }
        public string AccountId { get; set; }

        public ICollection<Message> Messages { get; set; }
        public int? EventId { get; set; }
        public ReservationEvent Event { get; set; }
        public Review Review { get; set; }
        
        public bool Arrived { get; set; }
        public bool Cancelled { get; set; }

        [NotMapped]
        public bool Passed => (DateTime.Now > DateTime);

        public Reservation()
        {
            Arrived = false;
            Cancelled = false;
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }
    }
}