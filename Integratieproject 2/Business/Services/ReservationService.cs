using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Repositories;

namespace Leisurebooker.Business.Services
{
    public class ReservationService : Service<Reservation>
    {
        public ReservationService() : base(new ReservationRepository()) { }
    }
}