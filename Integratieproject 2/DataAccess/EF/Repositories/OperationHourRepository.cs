using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class OperationHourRepository : Repository<OperationHours>
    {
        public OperationHourRepository(Context context) : base(context){}
        public OperationHourRepository() : base(ContextFactory.GetContext()) {}

        public override OperationHours Create(OperationHours entity)
        {
            this.Context.OpeningHours.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override OperationHours Read(int id, bool eager = false)
        {
            return this.Context.OpeningHours.Find(id);
        }

        public override void Update(OperationHours entity)
        {
            this.Context.OpeningHours.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var oh = Read(id);
            this.Context.OpeningHours.Remove(oh);
        }

        public override IEnumerable<OperationHours> Read(bool eager = false)
        {
            return this.Context.OpeningHours.AsEnumerable();
        }
    }
}
