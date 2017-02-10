﻿using System;
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
        public int AccountId { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
        public ReviewDto Review { get; set; }
        public bool Cancelled { get; set; }
    }
}