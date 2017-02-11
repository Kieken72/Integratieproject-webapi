using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leisurebooker.Business.Services
{
    public class AuthService : IDisposable
    {
        private readonly AuthRepository _repository;

        public AuthService()
        {
            _repository = new AuthRepository();
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            return await _repository.RegisterUser(userModel);
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            return await _repository.FindUser(userName, password);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
