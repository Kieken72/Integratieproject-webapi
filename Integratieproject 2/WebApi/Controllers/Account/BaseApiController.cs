using System.Net.Http;
using System.Web.Http;
using Leisurebooker.Business.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApi.Models;

namespace WebApi.Controllers.Account
{
    public class BaseApiController : ApiController
    {

        private ModelFactory _modelFactory;
        private readonly AuthService _authService = null;
        private readonly RoleService _roleService = null;
        protected readonly BranchService _branchService;

        protected AuthService AppUserManager => _authService ?? Request.GetOwinContext().GetUserManager<AuthService>();
        protected RoleService AppRoleManager => _roleService ?? Request.GetOwinContext().GetUserManager<RoleService>();

        public BaseApiController(BranchService branchService)
        {
            this._branchService = branchService;
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
