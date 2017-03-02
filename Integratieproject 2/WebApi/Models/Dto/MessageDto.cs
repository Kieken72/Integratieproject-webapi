using System;

namespace WebApi.Models.Dto
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int BranchId { get; set; }
        public string UserId { get; set; }
        public AccountDto User { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}