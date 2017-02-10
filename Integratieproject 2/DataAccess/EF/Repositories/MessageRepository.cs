using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(Context context) : base(context){}
        public MessageRepository() : base(ContextFactory.GetContext()) { }

        public override Message Create(Message entity)
        {
            throw new NotImplementedException();
        }

        public override Message Read(int id, bool eager = false)
        {
            throw new NotImplementedException();
        }

        public override void Update(Message entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Message> Read(bool eager = false)
        {
            throw new NotImplementedException();
        }
    }
}
