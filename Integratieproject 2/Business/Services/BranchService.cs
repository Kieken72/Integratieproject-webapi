using System.Collections.Generic;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class BranchService : Service<Branch>
    {
        public BranchService() : base(new BranchRepository()) { }

        public bool AddFavorite(int branchId, string accountId)
        {
            return ((BranchRepository)this.Repository).AddFavorite(branchId, accountId);
        }

        public bool RemoveFavorite(int branchId, string accountId)
        {
            return ((BranchRepository)this.Repository).RemoveFavorite(branchId, accountId);
        }

        public IEnumerable<Favorite> GetFavorites(string accountId)
        {
            return ((BranchRepository)this.Repository).GetFavorites(accountId);
        }
    }
}