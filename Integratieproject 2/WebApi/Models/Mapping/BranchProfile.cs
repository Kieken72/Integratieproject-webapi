﻿using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            this.CreateMap<Branch, BranchDto>();
            this.CreateMap<BranchDto, Branch>();

            this.CreateMap<Branch, CheckBranchDto>();
            this.CreateMap<CheckBranchDto, Branch>();

            this.CreateMap<Branch, ShortBranchDto>();
            this.CreateMap<ShortBranchDto, Branch>();
        }
    }
}