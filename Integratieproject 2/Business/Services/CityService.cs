using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class CityService : Service<City>
    {
        public CityService() : base(new CityRepository()) { }
    }
}