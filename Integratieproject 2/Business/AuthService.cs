using System;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Leisurebooker.Business
{
    public class RealAuthService : UserManager<AuthAccount>
    {
        public RealAuthService(IUserStore<AuthAccount> store)
            : base(store)
        {
        }

        public static RealAuthService Create(IdentityFactoryOptions<RealAuthService> options, IOwinContext context)
        {

            var appDbContext = ContextFactory.GetContext();
            var appUserManager = new RealAuthService(new UserStore<AuthAccount>(appDbContext))
            {
                EmailService = new EmailService()
            };

            appUserManager.UserValidator = new UserValidator<AuthAccount>(appUserManager)
            {
                RequireUniqueEmail = true
            }; appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<AuthAccount>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromHours(6)
                };
            }
            return appUserManager;
        }
    }
}