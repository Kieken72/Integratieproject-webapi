using System.Collections.Generic;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            CitiesSeeder.Seed(context);


            var manager = new UserManager<Account>(new UserStore<Account>(ContextFactory.GetContext()));

            var user = new Account()
            {
                UserName = "hello@leisurebooker.me",
                Email = "hello@leisurebooker.me",
                EmailConfirmed = true,
                Name = "Leisure",
                Surname = "booker"
            };

            manager.Create(user, "MySuperP@ssword!");
            var id = manager.FindByEmail("hello@leisurebooker.me").Id;
            var date = DateTime.Now;
            context.Companies.AddRange(new List<Company>()
            {
                new Company()
                {
                    Name = "Wima",
                    VATNumber = "BE0544984305",
                    CityId =342,
                    Street = "Vlierenpaal",
                    Number = "1",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            Name = "Filiaal Kontich",
                            Street = "Vlierenpaal",
                            Number = "1",
                            CityId = 342,
                            OpeningHours = new List<OperationHours>()
                            {
                                new OperationHours(DayOfWeek.Monday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Tuesday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Wednesday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Thursday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Friday, 11,30,17,30),
                                new OperationHours(DayOfWeek.Sunday, 11,30,17,30)
                            },
                            Rooms = new List<Room>()
                            {
                                new Room()
                                {
                                    Enabled = true,
                                    Name = "Main hall",
                                    Height = 100,
                                    Width = 100,
                                    Spaces = new List<Space>()
                                    {
                                        new Space()
                                        {
                                            Id=1,
                                            Enabled = true,
                                            Name = "Baan 1",
                                            MinPersons = 2,
                                            Persons = 8,
                                            Reservations = new List<Reservation>()
                                            {
                                                new Reservation()
                                                {
                                                    Id =1,
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id

                                                },new Reservation()
                                                {
                                                    Id=2,
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,11,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    Id=3,
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,13,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                }
                                            }
                                        },new Space()
                                        {
                                            Id=2,
                                            Enabled = true,
                                            Name = "Baan 2",
                                            MinPersons = 2,
                                            Persons = 8,
                                            Reservations = new List<Reservation>()
                                            {
                                                new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,11,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,13,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                }
                                            }
                                        },new Space()
                                        {Id=3,
                                            Enabled = true,
                                            Name = "Baan 3",
                                            MinPersons = 2,
                                            Persons = 8,Reservations = new List<Reservation>()
                                            {
                                                new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,11,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,13,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                }
                                            }
                                        },new Space()
                                        {Id=4,
                                            Enabled = true,
                                            Name = "Baan 4",
                                            MinPersons = 2,
                                            Persons = 8,Reservations = new List<Reservation>()
                                            {
                                                new Reservation()
                                                {Id=10,
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id

                                                },new Reservation()
                                                {Id=11,
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,11,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {Id=12,
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,13,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            Email = "post@wima.be"
                        }
                    }
                }
            });



        }
    }
}
