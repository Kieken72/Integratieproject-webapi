using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using System.Linq;
using System.Data.Entity;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class ReviewRepository : Repository<Review>
    {
        public ReviewRepository(Context context) : base(context){}
        public ReviewRepository() : base(ContextFactory.GetContext()) { }

        public override Review Create(Review entity)
        {
            this.Context.Reviews.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override Review Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.Context.Reviews
                    .Include(e=>e.Reservation)
                    .SingleOrDefault(t => t.Id == id);
            }
            return this.Context.Reviews
                    .SingleOrDefault(t => t.Id == id);
        }

        public override void Update(Review entity)
        {
            this.Context.Reviews.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var entity = Read(id);
            this.Context.Reviews.Remove(entity);
        }

        public override IEnumerable<Review> Read(bool eager = false)
        {
            if (eager)
            {
                return this.Context.Reviews
                    .Include(e => e.Reservation)
                    .AsEnumerable();
            }
            return this.Context.Reviews.AsEnumerable();
        }
    }
}
