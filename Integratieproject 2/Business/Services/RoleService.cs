using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Leisurebooker.Business.Services
{
    public class RoleService : RoleManager<IdentityRole>
    {
        public RoleService(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static RoleService Create(IdentityFactoryOptions<RoleService> options, IOwinContext context)
        {
            ContextFactory.Refresh();
            var appDbContext = ContextFactory.GetContext();
            var appRoleManager = new RoleService(new RoleStore<IdentityRole>(appDbContext));

            return appRoleManager;
        }
    }
}
