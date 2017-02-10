using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class SpaceRepository : Repository<Space>
    {
        public SpaceRepository(Context context) : base(context){ }
        public SpaceRepository() : base(ContextFactory.GetContext()) { }

        public override Space Create(Space entity)
        {
            throw new NotImplementedException();
        }

        public override Space Read(int id, bool eager = false)
        {
            throw new NotImplementedException();
        }

        public override void Update(Space entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Space> Read(bool eager = false)
        {
            throw new NotImplementedException();
        }
    }
}
