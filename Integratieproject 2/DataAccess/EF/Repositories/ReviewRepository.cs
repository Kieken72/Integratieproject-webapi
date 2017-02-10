using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class ReviewRepository : Repository<Review>
    {
        public ReviewRepository(Context context) : base(context){}
        public ReviewRepository() : base(ContextFactory.GetContext()) { }

        public override Review Create(Review entity)
        {
            throw new NotImplementedException();
        }

        public override Review Read(int id, bool eager = false)
        {
            throw new NotImplementedException();
        }

        public override void Update(Review entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Review> Read(bool eager = false)
        {
            throw new NotImplementedException();
        }
    }
}
