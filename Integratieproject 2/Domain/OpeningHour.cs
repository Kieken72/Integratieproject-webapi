using System;
using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace Leisurebooker.Business.Domain
{
    public class OperationHours : Entity
    {
        public Day Day { get; set; }

        //http://stackoverflow.com/questions/3567586/representing-time-not-date-and-time-in-c-sharp

        [DataType(DataType.Time)]
        public DateTime OpenTime { get; set; }

        public LocalTime CloseTime { get; set; }
        public int BranchId { get; set; }
    }
}