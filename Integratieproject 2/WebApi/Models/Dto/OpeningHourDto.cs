using Leisurebooker.Business.Domain;
using NodaTime;

namespace WebApi.Models.Dto
{
    public class OpeningHourDto
    {
        public Day Day { get; set; }
        public LocalTime OpenTime { get; set; }
        public LocalTime CloseTime { get; set; }
    }
}