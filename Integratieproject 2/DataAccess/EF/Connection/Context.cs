﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Leisurebooker.Business.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leisurebooker.DataAccess.EF.Connection
{
    [DbConfigurationType(typeof(Configuration))]
    public class Context : IdentityDbContext<Account>
    {
        public Context() : base("LeisurebookerDB_EFCodeFirst_Ninja", throwIfV1Schema:false)
        {
           // Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new CheckAndMigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
        }

        public Context(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new CheckAndMigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<OperationHours> OpeningHours { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AdditionalInfo> AdditionalInfos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        //public DbSet<Account> Accounts { get; set; }


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
            modelBuilder.Entity<OperationHours>().HasKey(e => e.Id);
            modelBuilder.Entity<Reservation>().HasKey(e => e.Id);
            modelBuilder.Entity<Message>().HasKey(e => e.Id);
            modelBuilder.Entity<Review>().HasKey(e => e.Id);
            modelBuilder.Entity<AdditionalInfo>().HasKey(e => e.Id);
            modelBuilder.Entity<Account>().HasKey(e => e.Id);
            modelBuilder.Entity<City>().HasKey(e => e.Id);

            modelBuilder.Entity<Favorite>().HasKey(e => new {e.BranchId, e.AccoundId});

            //modelBuilder.Entity<Event>().HasKey(e => e.Id);

            //modelBuilder.Entity<ReviewEvent>().HasKey(e => e.Id);
            //modelBuilder.Entity<MessageEvent>().HasKey(e => e.Id);
            //modelBuilder.Entity<ReservationEvent>().HasKey(e => e.Id);
        }

        private static void SetForeignKeys(DbModelBuilder modelBuilder)
        {
            SetOneToMany(modelBuilder);
            SetManyToMany(modelBuilder);
            SetOneToOne(modelBuilder);
        }


        private static void SetOneToMany(DbModelBuilder modelBuilder)
        {
            //Branches
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Branches)
                .WithRequired()
                .HasForeignKey(e => e.CompanyId);

            //Rooms
            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Rooms)
                .WithRequired()
                .HasForeignKey(e => e.BranchId);

            //AdditionalInfo
            modelBuilder.Entity<Branch>()
                .HasMany(e => e.AdditionalInfos)
                .WithRequired()
                .HasForeignKey(e => e.BranchId);

            //OpeningHours
            modelBuilder.Entity<Branch>()
                .HasMany(e => e.OpeningHours)
                .WithRequired()
                .HasForeignKey(e => e.BranchId);

            //Spaces
            modelBuilder.Entity<Room>()
                .HasMany(e => e.Spaces)
                .WithRequired()
                .HasForeignKey(e => e.RoomId);

            //Reservation
            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Reservations)
                .WithRequired()
                .HasForeignKey(e => e.BranchId);
            modelBuilder.Entity<Space>()
                .HasMany(e => e.Reservations)
                .WithRequired()
                .HasForeignKey(e => e.SpaceId);
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Reservations)
                .WithRequired()
                .HasForeignKey(e => e.UserId);
            

            //Messages
            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Messages)
                .WithRequired()
                .HasForeignKey(e => e.ReservationId);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Messages)
                .WithRequired()
                .HasForeignKey(e => e.BranchId);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Messages)
                .WithRequired()
                .HasForeignKey(e => e.UserId);

            //Reviews
            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Reviews)
                .WithRequired()
                .HasForeignKey(e => e.BranchId);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Reviews)
                .WithRequired()
                .HasForeignKey(e => e.UserId);




            //Cities
            modelBuilder.Entity<City>()
                .HasMany(e => e.SubCities)
                .WithOptional()
                .HasForeignKey(e => e.HeadCityId);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Companies)
                .WithRequired()
                .HasForeignKey(e => e.CityId);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Branches)
                .WithRequired()
                .HasForeignKey(e => e.CityId);
            





        }

        private static void SetManyToMany(DbModelBuilder modelBuilder)
        {

        }

        private static void SetOneToOne(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOptional(e => e.Review)
                .WithRequired(e=>e.Reservation);

            modelBuilder.Entity<Reservation>()
                .HasOptional(e => e.Event)
                .WithMany()
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<Message>()
                .HasOptional(e => e.Event)
                .WithMany()
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<Review>()
                .HasOptional(e => e.Event)
                .WithMany()
                .HasForeignKey(e => e.EventId);

            //modelBuilder.Entity<ReservationEvent>()
            //    .HasOptional(e => e.Reservation)
            //    .WithMany()
            //    .HasForeignKey(e => e.ReservationId);

            //modelBuilder.Entity<MessageEvent>()
            //    .HasOptional(e => e.Message)
            //    .WithMany()
            //    .HasForeignKey(e => e.MessageId);

            //modelBuilder.Entity<ReviewEvent>()
            //    .HasOptional(e => e.Review)
            //    .WithMany()
            //    .HasForeignKey(e => e.ReviewId);




        }

        private static void SetRequiredProperties(DbModelBuilder modelBuilder)
        {
            //
        }

        public void SetOptionalProperties(DbModelBuilder modelBuilder)
        {
            //throw new System.NotImplementedException();
            modelBuilder.Entity<City>().Property(m => m.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Event>().Property(m => m.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        public static Context Create()
        {
            return new Context();
        }
    }
}
