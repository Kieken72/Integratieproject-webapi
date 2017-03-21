using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Leisurebooker.Business.Services;
using Microsoft.AspNet.Identity;
using WebApi.Models.Dto;

namespace WebApi.Controllers.Account
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        public AccountsController(BranchService branchService) : base(branchService)
        {
        }

        [Authorize(Roles = "SuperAdmin")]
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        [Authorize(Roles = "SuperAdmin")]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string id)
        {
            var user = await this.AppUserManager.FindByIdAsync(id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Authorize(Roles = "SuperAdmin")]
        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Authorize]
        [Route("")]
        public IHttpActionResult GetUser()
        {
            var user = this.AppUserManager.FindUserByIdInclude(User.Identity.GetUserId());
            if (user != null)
            {
                var service = new MessageService();
                var mdl = this.TheModelFactory.Create(user);
                foreach (var reservation in mdl.Reservations)
                {
                    var messages = service.Get(e => e.ReservationId == reservation.Id).ToList();
                    var dtos = Mapper.Map<List<MessageDto>>(messages);
                    //reservation.Review = null;
                    reservation.Messages = dtos;
                }

                var favorites = BranchService.GetFavorites(User.Identity.GetUserId());
                mdl.Favorites = new List<ShortBranchDto>();
                foreach (var favorite in favorites)
                {
                    var branch = BranchService.Get(favorite.BranchId);
                    var dto = Mapper.Map<ShortBranchDto>(branch);
                    mdl.Favorites.Add(dto);
                }

                return Ok(mdl);
            }
            return NotFound();
        }

        [Authorize]
        [Route("favorite/{id}")]
        [HttpPost]
        public IHttpActionResult AddFavorite(int id)
        {
            if (!User.Identity.IsAuthenticated) return Unauthorized();
            var added = this.BranchService.AddFavorite(id, User.Identity.GetUserId());
            if (added)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [Route("favorite/{id}")]
        [HttpDelete]
        public IHttpActionResult RemoveFavorite(int id)
        {
            if (!User.Identity.IsAuthenticated) return Unauthorized();
            var removed = this.BranchService.RemoveFavorite(id, User.Identity.GetUserId());
            if (removed)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> EditUser([FromBody] EditUserBindingModel model)
        {
            var account = await this.AppUserManager.FindByIdAsync(User.Identity.GetUserId());

            account.Name = model.Name;
            account.Lastname = model.LastName;
            account.PhoneNumber = model.PhoneNumber;
            var result = this.AppUserManager.Update(account);

            return !result.Succeeded ? GetErrorResult(result) : Ok();
        }


        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Leisurebooker.Business.Domain.Account()
            {
                UserName = createUserModel.Email,
                Email = createUserModel.Email,
                Name = createUserModel.Name,
                Lastname = createUserModel.LastName,
                PhoneNumber =  createUserModel.PhoneNumber
            };

            IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

            var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

            await this.AppUserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));
        }
        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Ok("Bedant email succesvol gevalideerd.");
            }
            else
            {
                return GetErrorResult(result);
            }
        }

        [Authorize]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [Authorize(Roles = "SuperAdmin")]
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await this.AppUserManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();

            }

            return NotFound();

        }

        [Authorize(Roles = "SuperAdmin")]
        [Route("user/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);

            var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Any())
            {

                ModelState.AddModelError("", $"Roles '{string.Join(",", rolesNotExists)}' does not exixts in the system");
                return BadRequest(ModelState);
            }

            IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
