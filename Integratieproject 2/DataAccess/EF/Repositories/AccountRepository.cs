//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Data.Entity;

//using Leisurebooker.Business.Domain;
//using Leisurebooker.DataAccess.EF.Connection;

//namespace Leisurebooker.DataAccess.EF.Repositories
//{
//    public class AccountRepository : Repository<Account>
//    {
//        public AccountRepository(Context context) : base(context){ }
//        public AccountRepository() : base(ContextFactory.GetContext()) { }

//        public override Account Create(Account entity)
//        {
//            this.Context.Accounts.Add(entity);
//            this.Context.SaveChanges();
//            return entity;
//        }

//        public override Account Read(int id, bool eager = false)
//        {
//            if (eager)
//            {
//                return this.Context.Accounts
//                    .Include(e=>e.Favorites)
//                    .Include(e=>e.Messages)
//                    .Include(e=>e.Reservations)
//                    .Include(e=>e.Reviews)
//                    .FirstOrDefault(a => a.Id == id);
//            }
//            return this.Context.Accounts.Find(id);
//        }

//        public override void Update(Account entity)
//        {
//            this.Context.Accounts.Attach(entity);
//            this.Context.Entry(entity).State = EntityState.Modified;
//            this.Context.SaveChanges();
//        }

//        public override void Delete(int id)
//        {
//            this.Context.Accounts.Remove(this.Read(id));
//            this.Context.SaveChanges();
//        }

//        public override IEnumerable<Account> Read(bool eager = false)
//        {
//            if (eager)
//            {
//                return this.Context.Accounts
//                    .Include(e => e.Favorites)
//                    .Include(e => e.Messages)
//                    .Include(e => e.Reservations)
//                    .Include(e => e.Reviews)
//                    .AsEnumerable();
//            }
//            return this.Context.Accounts.AsEnumerable();
//        }
//    }
//}
