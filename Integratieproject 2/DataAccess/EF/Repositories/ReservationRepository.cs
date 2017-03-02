using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.EF.Repositories
{
    public class ReservationRepository : Repository<Reservation>
    {
        public ReservationRepository(Context context) : base(context){}
        public ReservationRepository() : base(ContextFactory.GetContext()) { }

        public override Reservation Create(Reservation entity)
        {
            //var count = this.Context.Events.Count()+1;
            var newEvent = new ReservationEvent()
            {
                //Id = count,
                BranchId = entity.BranchId,
                EventType = EventType.NewReservation,
                //Reservation = entity
            };
            //entity.Event = newEvent;
            entity = this.Context.Reservations.Add(entity);

            newEvent.ReservationId = entity.Id;
            //newEvent = this.Context.Events.Add(newEvent);
            this.Context.SaveChanges();
            return entity;
        }

        public override Reservation Read(int id, bool eager = false)
        {
            if (eager)
            {
                return this.Context.Reservations
                    .Include(e => e.Messages)
                    .Include(e=>e.Review)
                    .SingleOrDefault(t => t.Id == id);
            }
            return this.Context.Reservations.Find(id);
        }

        public override void Update(Reservation entity)
        {
            this.Context.Reservations.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var entity = Read(id);
            this.Context.Reservations.Remove(entity);
        }

        public override IEnumerable<Reservation> Read(bool eager = false)
        {
            if (eager)
            {
                return this.Context.Reservations
                    .Include(e => e.Messages)
                    .Include(e => e.Review)
                    .AsEnumerable();
            }
            return this.Context.Reservations.AsEnumerable();
        }
    }
}
