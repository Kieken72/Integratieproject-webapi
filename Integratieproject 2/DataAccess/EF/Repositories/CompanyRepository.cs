using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class CompanyRepository : Repository<Company>
    {
        public CompanyRepository() : base(ContextFactory.GetContext()) { }
        public CompanyRepository(Context context) : base(context){}

        public override Company Create(Company entity)
        {
            this.Context.Companies.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override Company Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.Context.Companies
                    .Include(t => t.Branches)
                    .SingleOrDefault(t => t.Id == id);
            }
            return this.Context.Companies.Find(id);
        }

        public override IEnumerable<Company> Read(bool eager = false)
        {
            if (eager)
            {
                return this.Context.Companies
                    .Include(e => e.Branches)
                    .AsEnumerable();
            }
            return this.Context.Companies.AsEnumerable();
        }

        public override void Update(Company entity)
        {
            this.Context.Entry<Company>(entity);
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            throw new NotSupportedException();
        }

        
    }
}
