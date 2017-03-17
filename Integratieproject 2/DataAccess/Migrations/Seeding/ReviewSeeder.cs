using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.Migrations.Seeding
{
    public class ReviewSeeder
    {
        public static readonly Random Random = new Random();
        public static void Seed(Context context)
        {
            var reservations = context.Reservations.Where(e=>e.DateTime<DateTime.Now);
            
            foreach (var reservation in reservations)
            {
                var random = Random.Next(1, 11);
                if (random != 10) continue;
                var resultRandom = Random.Next(2);
                var result = resultRandom == 0;
                var publicRandom = Random.Next(2);
                var publicB = publicRandom == 0;
                var review = new Review()
                {
                    BranchId = reservation.BranchId,
                    DateTime = reservation.EndDateTime.AddHours(Random.Next(6, 37)),
                    Result = result,
                    Text = result ? "Fantastisch!" : "Kon beter!",
                    UserId = reservation.UserId,
                    Public = publicB
                };
                reservation.Review = review;
                context.Reservations.Attach(reservation);
                context.Entry(reservation).State = EntityState.Modified;
            }
            //throw new EntityException(reviewList.Count+"");
            context.SaveChanges();
        }

        public static void Update(Context context, Reservation reservation, Review review)
        {
            reservation.Review = review;
            context.Reviews.Attach(review);
            context.Entry(reservation).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
