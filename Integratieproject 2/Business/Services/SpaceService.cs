using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class SpaceService : Service<Space>
    {
        public SpaceService() : base(new SpaceRepository()) { }
    }
}