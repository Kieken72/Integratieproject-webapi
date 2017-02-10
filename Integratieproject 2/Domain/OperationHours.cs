using System;
using System.ComponentModel.DataAnnotations;

namespace Leisurebooker.Business.Domain
{
    public class OperationHours : Entity
    {
        public DayOfWeek Day { get; set; }


        public TimeSpan FromTime { get; private set; }

        public TimeSpan ToTime { get; private set; }

        public int BranchId { get; set; }

        public OperationHours()
        {
        }

        public OperationHours(DayOfWeek dayOfWeek, TimeSpan fromTime, TimeSpan toTime) 
        : this(dayOfWeek, fromTime.Hours, fromTime.Minutes, toTime.Hours, toTime.Minutes) { }

        public OperationHours(DayOfWeek dayOfWeek, int fromHours, int fromMinutes, int toHours, int toMinutes)
        {
            if (fromHours < 0 || fromHours > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(fromHours), "fromHours must be in the range 0 to 23 inclusive");
            }

            if (toHours < 0 || toHours > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(toHours), "toHours must be in the range 0 to 23 inclusive");
            }

            if (fromMinutes < 0 || fromMinutes > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(fromMinutes), "fromMinutes must be in the range 0 to 59 inclusive");
            }

            if (toMinutes < 0 || toMinutes > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(toMinutes), "toMinutes must be in the range 0 to 59 inclusive");
            }

            this.FromTime = new TimeSpan(fromHours, fromMinutes, 0);
            this.ToTime = new TimeSpan(toHours, toMinutes, 0);

            if (this.FromTime >= this.ToTime)
            {
                throw new ArgumentException("From Time must be before To Time");
            }

            this.Day = dayOfWeek;
        }

        public bool IsOpen(int hours, int minutes)
        {
            if (hours < 0 || hours > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hours), "Hour must be in the range 0 to 23 inclusive");
            }

            if (minutes < 0 || minutes > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes must be in the range 0 to 59 inclusive");
            }

            var timespan = new TimeSpan(hours,minutes,0);
            return timespan >= FromTime || timespan <= ToTime;
        }
    }
}