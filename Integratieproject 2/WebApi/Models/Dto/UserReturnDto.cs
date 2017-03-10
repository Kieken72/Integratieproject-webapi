using System.Collections.Generic;

namespace WebApi.Models.Dto
{
    public class UserReturnDto
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public bool EmailConfirmed { get; set; }
        public IList<string> Roles { get; set; }
        //public IList<System.Security.Claims.Claim> Claims { get; set; }
        public ICollection<ShortBranchDto> Favorites { get; set; }
        public ICollection<ReservationDto> Reservations { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
    }
}