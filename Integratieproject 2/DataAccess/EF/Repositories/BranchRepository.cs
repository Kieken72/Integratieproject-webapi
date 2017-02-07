﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class BranchRepository : Repository<Branch>
    {
        public BranchRepository(Context context) : base(context){}
        public BranchRepository() : base(ContextFactory.GetContext()) {}

        public override Branch Create(Branch entity)
        {
            this.Context.Branches.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public override Branch Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.Context.Branches
                    .Include(e=>e.Rooms)
                    .Include(e=>e.OpeningHours)
                    .Include(e=>e.AdditionalInfos)
                    .SingleOrDefault(t => t.Id == id);
            }
            return this.Context.Branches.Find(id);
        }

        public override void Update(Branch entity)
        {
            this.Context.Entry<Branch>(entity);
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var branch = Read(id);
            this.Context.Branches.Remove(branch);
        }

        public override IEnumerable<Branch> Read(bool eager = false)
        {
            if (eager)
            {
                return this.Context.Branches
                    .Include(e => e.Rooms)
                    .Include(e => e.OpeningHours)
                    .Include(e => e.AdditionalInfos)
                    .AsEnumerable();
            }
            return this.Context.Branches.AsEnumerable();
        }
    }
}