using System;
using Leisurebooker.Business.Domain;

namespace WebApi.Models.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public bool Result { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public bool Public { get; set; }
        public Reservation Reservation { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
    }
}