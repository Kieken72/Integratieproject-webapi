using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class ReservationRepository : Repository<Reservation>
    {
        public ReservationRepository(Context context) : base(context){}
        public ReservationRepository() : base(ContextFactory.GetContext()) { }

        public override Reservation Create(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public override Reservation Read(int id, bool eager = false)
        {
            throw new NotImplementedException();
        }

        public override void Update(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Reservation> Read(bool eager = false)
        {
            throw new NotImplementedException();
        }
    }
}
