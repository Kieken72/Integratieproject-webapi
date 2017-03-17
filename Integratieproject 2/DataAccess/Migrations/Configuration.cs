using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Leisurebooker.DataAccess.Migrations.Seeding;

namespace Leisurebooker.DataAccess.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        private const int City = 342;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            CitiesSeeder.Seed(context);

            var users = AccountSeeder.Seed(context);

            CompanySeeder.Seed(context);

            ReservationSeeder.Seed(context, users);

            ReviewSeeder.Seed(context);


            /*
            var date = DateTime.Now.AddDays(1);
            context.Companies.Add(
            
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
                            Street = "Gemeenteplein",
                            Number = "1",
                            Picture = "Content/bowling.jpg",
                            CityId = City,
                            OpeningHours = new List<OperationHours>()
                            {
                                new OperationHours(DayOfWeek.Monday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Tuesday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Wednesday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Thursday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Friday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Sunday, 14,00,23,30)
                            },
                            AdditionalInfos = new List<AdditionalInfo>()
                            {
                                new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.PaymentMethod,
                                    Value = "VISA"
                                },new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.PaymentMethod,
                                    Value = "BANCONTACT"
                                },new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.PaymentMethod,
                                    Value = "MASTERCARD"
                                },new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.Accessibility,
                                    Value = "WHEELCHAIR"
                                },
                                new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.Facility,
                                    Value = "WIFI"
                                },

                            },
                            Description = "Sportieve ontspanning in een gezellig kader... dat is Superbowl! "+
                            "Tien bowlingbanen, drie pooltafels, een airhockey tafel en een uitgebreide keuze snacks en drankjes, alles tegen democratische prijzen."+
                            "kunt tevens deelnemen aan onze competities."+
                            "En... waarom viert u het volgende verjaardagsfeestje van U of een van uw kinderen niet in Superbowl? Wij zijn er klaar voor!",
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
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,18,00,00),
                                                    AccountId = id,
                                                    Review = new Review()
                                                    {
                                                        DateTime = DateTime.Today.AddDays(1),
                                                        Public = true,
                                                        Result = true,
                                                        Text = "KEIGOED",
                                                        UserId = user.Id
                                                    }

                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,14,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,18,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,20,30,00),
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
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,14,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,18,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,20,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,20,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,22,00,00),
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
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,14,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,18,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,20,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,22,30,00),
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
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,14,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,18,00,00),
                                                    AccountId = id

                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,18,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,20,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,20,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,22,30,00),
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
            });

            context.SaveChanges();

            context.Companies.Add(

                new Company()
                {
                    Name = "Suerbowl",
                    VATNumber = "BEXXXXXXXXXX",
                    CityId = 342,
                    Street = "Groenplaats",
                    Number = "1",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            Name = "Superbowl Kontich",
                            Street = "Gemeenteplein",
                            Number = "1",
                            Picture = "Content/bowling.jpg",
                            CityId = City,
                            OpeningHours = new List<OperationHours>()
                            {
                                new OperationHours(DayOfWeek.Monday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Tuesday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Wednesday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Thursday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Friday, 14,00,23,30),
                                new OperationHours(DayOfWeek.Sunday, 14,00,23,30)
                            },
                            AdditionalInfos = new List<AdditionalInfo>()
                            {
                                new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.PaymentMethod,
                                    Value = "MASTERCARD"
                                },new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.PaymentMethod,
                                    Value = "VISA"
                                },new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.PaymentMethod,
                                    Value = "BANCONTACT"
                                },new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.Accessibility,
                                    Value = "WHEELCHAIR"
                                },
                                new AdditionalInfo()
                                {
                                    Type = AdditionalInfoType.Facility,
                                    Value = "WIFI"
                                },

                            },
                            Description = "Sportieve ontspanning in een gezellig kader... dat is Superbowl! "+
                            "Tien bowlingbanen, drie pooltafels, een airhockey tafel en een uitgebreide keuze snacks en drankjes, alles tegen democratische prijzen."+
                            "kunt tevens deelnemen aan onze competities."+
                            "En... waarom viert u het volgende verjaardagsfeestje van U of een van uw kinderen niet in Superbowl? Wij zijn er klaar voor!",
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
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,15,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,17,00,00),
                                                    AccountId = id

                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,17,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,19,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,19,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,21,00,00),
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
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,14,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,18,30,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,18,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,19,30,00),
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
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,14,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,18,30,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,20,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,22,30,00),
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
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,14,00,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,16,00,00),
                                                    AccountId = id

                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,16,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,18,30,00),
                                                    AccountId = id
                                                },new Reservation()
                                                {
                                                    AmountOfPersons = 2,
                                                    DateTime = new DateTime(date.Year,date.Month,date.Day,22,30,00),
                                                    EndDateTime = new DateTime(date.Year,date.Month,date.Day,23,00,00),
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
                });
            try
            {
                context.SaveChanges();
              
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                throw;
            }
            */




        }
    }
}
