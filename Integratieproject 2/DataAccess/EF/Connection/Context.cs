using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Leisurebooker.Business.Domain;

namespace Leisurebooker.DataAccess.EF.Connection
{
    [DbConfigurationType(typeof(Configuration))]
    public class Context : DbContext
    {
        public Context() : base("LeisurebookerDB_EFCodeFirst_Ninja_TEST")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>("LeisurebookerDB_EFCodeFirst_Ninja_TEST"));
        }

        public Context(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>(nameOrConnectionString));
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

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            SetPrimaryKeys(modelBuilder);
            SetForeignKeys(modelBuilder);
            SetOptionalProperties(modelBuilder);
            SetRequiredProperties(modelBuilder);
        }

        private static void SetPrimaryKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(e => e.Id);
            modelBuilder.Entity<Branch>().HasKey(e => e.Id);
            modelBuilder.Entity<Room>().HasKey(e => e.Id);
            modelBuilder.Entity<Space>().HasKey(e => e.Id);
            modelBuilder.Entity<OpeningHour>().HasKey(e => e.Id);
            modelBuilder.Entity<Reservation>().HasKey(e => e.Id);
            modelBuilder.Entity<Message>().HasKey(e => e.Id);
            modelBuilder.Entity<Review>().HasKey(e => e.Id);
            modelBuilder.Entity<AdditionalInfo>().HasKey(e => e.Id);
        }

        private static void SetForeignKeys(DbModelBuilder modelBuilder)
        {
            SetOneToMany(modelBuilder);
            SetManyToMany(modelBuilder);
        }


        private static void SetOneToMany(DbModelBuilder modelBuilder)
        {
            //Branches
            modelBuilder.Entity<Company>().HasMany(e => e.Branches)
                .WithRequired()
                .HasForeignKey(e => e.CompanyId);
        }
        private static void SetManyToMany(DbModelBuilder modelBuilder)
        {
            //throw new System.NotImplementedException();
        }

        private static void SetRequiredProperties(DbModelBuilder modelBuilder)
        {
            //throw new System.NotImplementedException();
        }

        public void SetOptionalProperties(DbModelBuilder modelBuilder)
        {
            //throw new System.NotImplementedException();
        }
    }
}
