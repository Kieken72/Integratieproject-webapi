using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class RoomRepository : Repository<Room>
    {
        public RoomRepository(Context context) : base(context){ }
        public RoomRepository() : base(ContextFactory.GetContext()) { }

        public override Room Create(Room entity)
        {
            throw new NotImplementedException();
        }

        public override Room Read(int id, bool eager = false)
        {
            throw new NotImplementedException();
        }

        public override void Update(Room entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Room> Read(bool eager = false)
        {
            throw new NotImplementedException();
        }
    }
}
