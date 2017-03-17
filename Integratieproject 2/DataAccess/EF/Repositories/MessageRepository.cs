using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using System.Data.Entity;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(Context context) : base(context){}
        public MessageRepository() : base(ContextFactory.GetContext()) { }

        public override Message Create(Message entity)
        {
            this.Context.Messages.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override Message Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.Context.Messages
                    .SingleOrDefault(t => t.Id == id);
            }
            return this.Context.Messages.Find(id);
        }

        public override void Update(Message entity)
        {
            this.Context.Messages.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var entity = Read(id);
            this.Context.Messages.Remove(entity);
        }

        public override IEnumerable<Message> Read(bool eager = false)
        {
            if (eager)
            {
                return this.Context.Messages.AsEnumerable();
            }
            return this.Context.Messages.AsEnumerable();
        }
    }
}
