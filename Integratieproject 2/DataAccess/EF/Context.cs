using System.Data.Entity;
using Leisurebooker.Business.Domain;

namespace Leisurebooker.DataAccess.EF
{
    [DbConfigurationType(typeof(Configuration))]
    public class Context : DbContext
    {
        public Context() : base("LeisurebookerDB_EFCodeFirst_Ninja_TEST")
        {
        }

        public Context(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AdditionalInfo> AdditionalInfos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
