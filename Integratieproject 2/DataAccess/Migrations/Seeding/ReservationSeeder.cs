using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.Migrations.Seeding
{
    public class ReservationSeeder
    {
        public static readonly Random Random = new Random();
        public static void Seed(Context context, IEnumerable<Account> users)
        {
            if (context.Reservations.Any()) return;
            var branches = context.Branches.ToList();
            var index = 1;
            foreach (var account in users)
            {
                if (account.Email == "hello@leisurebooker.me") continue;
                foreach (var branch in branches)
                {
                    var reservations = new List<Reservation>();
                    for (int i = 1; i < 365; i++)
                    {
                        //Make new Date
                        var date = DateTime.Now;
                        date = date.AddDays(100);
                        date = date.AddDays(-i);
                       

                        //Openinghours
                        var operationHours = branch.OpeningHours.FirstOrDefault(e => e.Day == date.DayOfWeek);
                        if(operationHours == null)
                            continue;
                        
                        date = new DateTime(date.Year, date.Month, date.Day, operationHours.FromTime.Hours, operationHours.FromTime.Minutes,0);

                        //GetRooms And first space
                        var roomIds = context.Rooms.Where(e => e.BranchId == branch.Id).Select(e=>e.Id);
                        var spaces = context.Spaces.Where(e => roomIds.Contains(e.RoomId));
                        Space firstFreeSpace = null;
                        foreach (var space in spaces)
                        {
                            if (space.Reservations == null)
                            {
                                firstFreeSpace = space;
                            }
                            if (space.Reservations != null && space.Reservations.Any())
                            {
                                continue;
                            }
                            firstFreeSpace = space;
                        }
                        if(firstFreeSpace==null)
                            continue;

                        var showed = date < DateTime.Now;
                        var reservation = new Reservation()
                        {
                            AmountOfPersons = Random.Next(1, firstFreeSpace.Persons + 1),
                            DateTime = date,
                            BranchId = branch.Id,
                            EndDateTime = date.AddHours(2),
                            SpaceId = firstFreeSpace.Id,
                            UserId = account.Id,
                            Arrived = showed,
                            CreatedOn = date.AddHours(-360),
                            ModifiedOn = date.AddHours(-360)

                        };
                        
                        reservations.Add(reservation);
                    }
                    context.Reservations.AddRange(reservations);
                }
                index++;
            }
            context.SaveChanges();
        }

    }

}
