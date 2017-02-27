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
        private UrlHelper _UrlHelper;
        private AuthService _AppUserManager;

        public ModelFactory(HttpRequestMessage request, AuthService appUserManager)
        {
            _UrlHelper = new UrlHelper(request);
            _AppUserManager = appUserManager;
        }

        public UserReturnModel Create(Account appUser)
        {
            return new UserReturnModel
            {
                Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                Firstname = appUser.Name,
                Surname = appUser.Surname,
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Roles = _AppUserManager.GetRolesAsync(appUser.Id).Result,
                //Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result,
                Reservations = Mapper.Map<ICollection<ReservationDto>>(appUser.Reservations),
                Reviews = Mapper.Map<ICollection<ReviewDto>>(appUser.Reviews),
                Messages = Mapper.Map<ICollection<MessageDto>>(appUser.Messages),
                //Favorites = Mapper.Map<ICollection<BranchDto>>(appUser.Favorites)

            };
        }
        public RoleReturnModel Create(IdentityRole appRole)
        {

            return new RoleReturnModel
            {
                Url = _UrlHelper.Link("GetRoleById", new { id = appRole.Id }),
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }
}