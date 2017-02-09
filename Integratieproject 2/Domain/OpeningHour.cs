﻿using NodaTime;

namespace Leisurebooker.Business.Domain
{
    public class OpeningHour : Entity
    {
        public Day Day { get; set; }
        public LocalTime OpenTime { get; set; }
        public LocalTime CloseTime { get; set; }
        public int BranchId { get; set; }
    }
}