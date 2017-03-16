using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Leisurebooker.Business.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Mapping
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            this.CreateMap<Account, AccountDto>();
            this.CreateMap<AccountDto, Account>();

            this.CreateMap<Account, FullAccountDto>();
            this.CreateMap<FullAccountDto, Account>();
        }
    }
}