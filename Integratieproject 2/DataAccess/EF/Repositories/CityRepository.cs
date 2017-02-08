using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class CityRepository : Repository<City>
    {
        public CityRepository(Context context) : base(context){}
        public CityRepository() : base(ContextFactory.GetContext()) {}

        public override City Create(City entity)
        {
            this.Context.Cities.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override City Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.Context.Cities
                    .Include(e=>e.SubCities)
                    .Include(e=>e.HeadCity)
                    .SingleOrDefault(t => t.Id == id);
            }
            return this.Context.Cities.Find(id);
        }

        public override void Update(City entity)
        {
            this.Context.Cities.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var entity = Read(id);
            this.Context.Cities.Remove(entity);
        }

        public override IEnumerable<City> Read(bool eager = false)
        {
            if (eager)
            {
                return this.Context.Cities
                    .Include(e => e.SubCities)
                    .Include(e=>e.HeadCity)
                    .AsEnumerable();
            }
            return this.Context.Cities.AsEnumerable();
        }
    }
}
