using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Dto
{
    public class BranchDto
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public int CityId { get; set; }
        public CityDto City { get; set; }

        public string Picture { get; set; }
        public string Description { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int CompanyId { get; set; }

        public ICollection<RoomDto> Rooms { get; set; }
        public ICollection<OperationHoursDto> OpeningHours { get; set; }
        public ICollection<AdditionalInfoDto> AdditionalInfos { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
        public ICollection<ReservationDto> Reservations { get; set; }
    }

    public class CheckBranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public int CityId { get; set; }
        public CityDto City { get; set; }

        public bool Available { get; set; }
        public CheckMessage Message { get; set; }

    }

    public class AvailableBranchUri
    {
        public int  Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hours  { get; set; }
        public int Minutes { get; set; }
        public int Amount { get; set; }
    }

    public enum CheckMessage
    {
        Closed,
        Full,
        Free
    }
}