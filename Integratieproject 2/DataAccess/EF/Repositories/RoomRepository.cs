using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            this.Context.Rooms.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override Room Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.Context.Rooms
                    .Include(e => e.Spaces)
                    .SingleOrDefault(e => e.Id == id);
            }
            return this.Context.Rooms.Find(id);
        }

        public override void Update(Room entity)
        {
            this.Context.Rooms.Attach(entity);
            this.Context.Entry(entity).State =EntityState.Modified;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var entity = Read(id);
            this.Context.Rooms.Remove(entity);
        }

        public override IEnumerable<Room> Read(bool eager = false)
        {
            if (eager)
            {
                return this.Context.Rooms
                    .Include(e => e.Spaces)
                    .AsEnumerable();
            }
            return this.Context.Rooms.AsEnumerable();
        }
    }
}
