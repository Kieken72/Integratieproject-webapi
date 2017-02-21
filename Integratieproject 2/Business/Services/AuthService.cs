using System;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Leisurebooker.Business.Services
{
    public class AuthService : UserManager<Account>
    {
        public AuthService(IUserStore<Account> store)
            : base(store){}
        public AuthService() : base(new UserStore<Account>(ContextFactory.GetContext())) { }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await this.FindAsync(userName, password);

            return user;
        }
        public static AuthService Create(IdentityFactoryOptions<AuthService> options, IOwinContext context)
        {
            ContextFactory.Refresh();
            var appDbContext = ContextFactory.GetContext();
            var appUserManager = new AuthService(new UserStore<Account>(appDbContext))
            {
                EmailService = new EmailService()
            };

            appUserManager.UserValidator = new UserValidator<Account>(appUserManager)
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
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<Account>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromHours(6)
                };
            }
            return appUserManager;
        }
    }
}