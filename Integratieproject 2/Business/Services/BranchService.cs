using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class BranchService : Service<Branch>
    {
        public BranchService() : base(new BranchRepository()) { }

        public void AddFavorite(int branchId, Account account)
        {
            ((BranchRepository)this.Repository).AddFavorite(branchId, account);
        }
    }
}