using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class CompanyService : Service<Company>
    {
        public CompanyService() : base(new CompanyRepository()) {}
    }
}
