//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using Leisurebooker.Business;
//using Leisurebooker.Business.Domain;
//using Leisurebooker.Business.Services;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;

//namespace WebApi.Controllers
//{
//    [RoutePrefix("api/favorites")]
//    public class FavoritesController : BaseApiController
//    {

//        private readonly IService<Branch> _branchService;

//        public FavoritesController(IService<Branch> branchService)
//        {
//            _branchService = branchService;
//        }

        
//        [Authorize]
//        // POST: api/Favorites
//        public IHttpActionResult Post(int id)
//        {
//            if (User.Identity.IsAuthenticated)
//            {
//                var branch = _branchService.Get(id, collections:true);
//                if (branch != null)
//                {
//                    var acc = this.AppUserManager.FindById(User.Identity.GetUserId());
                   
//                    if (branch.Favorites == null)
//                    {
//                        branch.Favorites = new List<Account>();
//                    }
//                    branch.Favorites.Add(acc);
//                    if (acc.Favorites == null)
//                    {
//                        acc.Favorites = new List<Branch>();
//                    }
//                    branch.CityId = 0;
//                    branch.City = null;
//                    acc.Favorites.Add(branch);
//                    this.AppUserManager.Update(acc);
//                    //_branchService.Change(branch);
//                    return Ok();
//                }
//                return NotFound();

//            }
//            return Unauthorized();
//        }


//        [Authorize]
//        // DELETE: api/Favorites/5
//        public IHttpActionResult Delete(int id)
//        {
//            if (User.Identity.IsAuthenticated)
//            {
//                var branch = _branchService.Get(id, collections:true);
//                if (branch != null)
//                {
//                    var acc = this.AppUserManager.FindById(User.Identity.GetUserId());
//                    branch.Favorites.Remove(acc);
//                    _branchService.Change(branch);
//                    return Ok();
//                }
//                return NotFound();

//            }
//            return Unauthorized();
//        }
//    }
//}
