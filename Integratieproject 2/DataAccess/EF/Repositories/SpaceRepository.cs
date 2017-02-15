using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
            this.Context.Spaces.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override Space Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.Context.Spaces
                    .Include(e => e.Reservations)
                    .SingleOrDefault(e=>e.Id==id);
            }
            return this.Context.Spaces.Find(id);
        }

        public override void Update(Space entity)
        {
            this.Context.Spaces.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var entity = Read(id);
            this.Context.Spaces.Remove(entity);
        }

        public override IEnumerable<Space> Read(bool eager = false)
        {
            if (eager)
            {
                return this.Context.Spaces
                    .Include(e => e.Reservations)
                    .AsEnumerable();
            }
            return this.Context.Spaces.AsEnumerable();
        }
    }
}
