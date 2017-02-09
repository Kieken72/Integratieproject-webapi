using System;
using Leisurebooker.Business.Domain;

namespace WebApi.Models.Dto
{
    public class OperationHoursDto
    {
        public DayOfWeek Day { get; set; }
        
        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }

        public int BranchId { get; set; }
    }
}