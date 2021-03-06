using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;
using AutoMapper;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApi.Models.Dto;

namespace WebApi.Models
{
    public class ModelFactory
    {
        private readonly UrlHelper _urlHelper;
        private readonly AuthService _appUserManager;

        public ModelFactory(HttpRequestMessage request, AuthService appUserManager)
        {
            _urlHelper = new UrlHelper(request);
            _appUserManager = appUserManager;
        }

        public UserReturnDto Create(Account appUser)
        {
            return new UserReturnDto
            {
                Url = _urlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                Name = appUser.Name,
                Lastname = appUser.Lastname,
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Roles = _appUserManager.GetRolesAsync(appUser.Id).Result,
                PhoneNumber = appUser.PhoneNumber,
                //Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result,
                Reservations = Mapper.Map<ICollection<ReservationDto>>(appUser.Reservations),
                Reviews = Mapper.Map<ICollection<ReviewDto>>(appUser.Reviews),
                Messages = Mapper.Map<ICollection<MessageDto>>(appUser.Messages)

            };
        }
        public RoleReturnDto Create(IdentityRole appRole)
        {

            return new RoleReturnDto
            {
                Url = _urlHelper.Link("GetRoleById", new { id = appRole.Id }),
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }
}