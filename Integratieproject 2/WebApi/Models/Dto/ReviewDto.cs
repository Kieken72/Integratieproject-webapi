﻿using System;
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
        //public ReservationDto Reservation { get; set; }
        public int ReservationId { get; set; }
        public int BranchId { get; set; }
        public string UserId { get; set; }
        public AccountDto User { get; set; }

        public ReviewDto()
        {
            DateTime = DateTime.Now;
        }
    }
}