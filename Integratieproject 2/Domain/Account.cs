using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leisurebooker.Business.Domain
{
    public class Account : IdentityUser
    {
        
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Branch> Favorites { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public int? BranchId { get; set; }
        public virtual Branch ManagerInBranch { get; set; }

        public DateTime CreatedOn { get; set; }

        public Account()
        {
            CreatedOn = DateTime.Now;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }



    }
}
