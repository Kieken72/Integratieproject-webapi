using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class RoomService : Service<Room>
    {
        public RoomService() : base(new RoomRepository()) { }
    }
}