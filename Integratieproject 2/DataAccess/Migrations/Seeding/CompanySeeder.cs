using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.Migrations.Seeding
{
    public class CompanySeeder
    {
        public static void Seed(Context context)
        {
            if (context.Companies.Any()) return;
            var company1 = new Company
            {
                Name = "Megabowling NV",
                VATNumber = "BE0478331645",
                CityId = 2422,
                Street = "Grote Markt",
                Number = "4",
                Branches = new List<Branch>()
                {
                    new Branch()
                    {
                        Name = "Bowling Stones Wommelgem",
                        Street = "Autolei",
                        Number = "113",
                        CityId = 262,
                        Email = "wommelgem@bowlingstones.be",
                        Picture = "Content/bowling-wommelgem-1.jpg",
                        PhoneNumber = "033226303",
                        Description =
                            "Bowling Stones Wommelgem is perfect uitgerust om van élke gelegenheid een feest te maken. De knappe locatie maakt het helemaal af.",
                        OpeningHours = new List<OperationHours>()
                        {
                            new OperationHours(DayOfWeek.Monday, 17, 00, 23, 00),
                            new OperationHours(DayOfWeek.Tuesday, 17, 00, 23, 00),
                            new OperationHours(DayOfWeek.Wednesday, 14, 00, 23, 00),
                            new OperationHours(DayOfWeek.Thursday, 17, 00, 23, 00),
                            new OperationHours(DayOfWeek.Friday, 17, 00, 23, 59),
                            new OperationHours(DayOfWeek.Saturday, 12, 00, 23, 59),
                            new OperationHours(DayOfWeek.Sunday, 14, 00, 23, 00),
                        },
                        AdditionalInfos = new List<AdditionalInfo>()
                        {
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "VISA"
                            },
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "BANCONTACT"
                            },
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "MASTERCARD"
                            },
                            new AdditionalInfo()
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
                        Rooms = new List<Room>()
                        {
                            new Room()
                            {
                                Enabled = true,
                                Name = "Hoofdgebouw",
                                Height = 100,
                                Width = 500,
                                Spaces = new List<Space>()
                                {
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 1",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 2",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 3",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 4",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 5",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 6",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 7",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 8",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 9",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 10",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 11",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 12",
                                        MinPersons = 1,
                                        Persons = 8
                                    }
                                }
                            }
                        }
                    }
                }
            };

            context.Companies.Add(company1);
            context.SaveChanges();
            //Branches for C1





            var company2 = new Company()
            {
                Name = "Restobowl NV",
                VATNumber = "BE0423502889",
                CityId = 2422,
                Street = "Grote Markt",
                Number = "4",
                Branches = new List<Branch>()
                {
                    new Branch()
                    {
                        Name = "Bowling Stones Antwerpen",
                        Street = "Noorderlaan",
                        Number = "104A",
                        CityId = 246,
                        Email = "antwerpen@bowlingstones.be",
                        Picture = "Content/bowling-antwerpen-3.jpg",
                        PhoneNumber = "035411313",
                        Description =
                            "Bowling Stones Antwerpen is de ‘trendy place to be’. Om te bowlen, voor een avondje uit met vrienden of een hip en lekker etentje.",
                        OpeningHours = new List<OperationHours>()
                        {
                            new OperationHours(DayOfWeek.Monday, 17, 00, 23, 00),
                            new OperationHours(DayOfWeek.Tuesday, 17, 00, 23, 00),
                            new OperationHours(DayOfWeek.Wednesday, 14, 00, 23, 00),
                            new OperationHours(DayOfWeek.Thursday, 14, 00, 23, 00),
                            new OperationHours(DayOfWeek.Friday, 14, 00, 23, 59),
                            new OperationHours(DayOfWeek.Saturday, 12, 00, 23, 59),
                            new OperationHours(DayOfWeek.Sunday, 14, 00, 23, 00),
                        },
                        AdditionalInfos = new List<AdditionalInfo>()
                        {
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "VISA"
                            },
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "BANCONTACT"
                            },
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "MASTERCARD"
                            },
                            new AdditionalInfo()
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
                        Rooms = new List<Room>()
                        {
                            new Room()
                            {
                                Enabled = true,
                                Name = "Hoofdgebouw",
                                Height = 100,
                                Width = 500,
                                Spaces = new List<Space>()
                                {
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 1",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 2",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 3",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 4",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 5",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 6",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 7",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 8",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 9",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 10",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 11",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 12",
                                        MinPersons = 1,
                                        Persons = 8
                                    }
                                }
                            }
                        }
                    },
                    new Branch()
                    {
                        Name = "Bowling Stones Brussel",
                        Street = "Steenweg op Brussel",
                        Number = "397",
                        CityId = 0,
                        Email = "brussel@bowlingstones.be",
                        Picture = "Content/Bowling Stones Brussel Bowling Banen Bowling.png",
                        PhoneNumber = "025323626",
                        Description =
                            "Zin in een avond vol fun in een hippe omgeving? Kom bowlen of dineren bij Bowling Stones Brussel. We hebben gegarandeerd een formule die bij je past !",
                        OpeningHours = new List<OperationHours>()
                        {
                            new OperationHours(DayOfWeek.Monday, 14, 00, 23, 00),
                            new OperationHours(DayOfWeek.Tuesday, 14, 00, 23, 00),
                            new OperationHours(DayOfWeek.Wednesday, 14, 00, 23, 00),
                            new OperationHours(DayOfWeek.Thursday, 14, 00, 23, 00),
                            new OperationHours(DayOfWeek.Friday, 14, 00, 23, 59),
                            new OperationHours(DayOfWeek.Saturday, 14, 00, 23, 59),
                            new OperationHours(DayOfWeek.Sunday, 14, 00, 23, 00),
                        },
                        AdditionalInfos = new List<AdditionalInfo>()
                        {
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "VISA"
                            },
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "BANCONTACT"
                            },
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "MASTERCARD"
                            },
                            new AdditionalInfo()
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
                        Rooms = new List<Room>()
                        {
                            new Room()
                            {
                                Enabled = true,
                                Name = "Hoofdgebouw",
                                Height = 100,
                                Width = 500,
                                Spaces = new List<Space>()
                                {
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 1",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 2",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 3",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 4",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 5",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 6",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 7",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 8",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 9",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 10",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 11",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 12",
                                        MinPersons = 1,
                                        Persons = 8
                                    }
                                }
                            }
                        }
                    },
                    new Branch()
                    {
                        Name = "Bowling Stones Oudenaarde",
                        Street = "Gobelinstraat",
                        Number = "1",
                        CityId = 2684,
                        Email = "oudenaarde@bowlingstones.be",
                        PhoneNumber = "055305958",
                        Picture = "Content/int-oudenaarde-3.jpg",
                        Description =
                            "Een sfeervolle, hippe locatie waar lekker eten en fun vanzelfsprekend zijn. Kom genieten bij Bowling Stones Oudenaarde.",
                        OpeningHours = new List<OperationHours>()
                        {
                            new OperationHours(DayOfWeek.Tuesday, 17, 00, 22, 00),
                            new OperationHours(DayOfWeek.Wednesday, 14, 00, 22, 00),
                            new OperationHours(DayOfWeek.Thursday, 17, 00, 22, 00),
                            new OperationHours(DayOfWeek.Friday, 17, 00, 23, 00),
                            new OperationHours(DayOfWeek.Saturday, 14, 00, 23, 00),
                            new OperationHours(DayOfWeek.Sunday, 14, 00, 20, 00),
                        },
                        AdditionalInfos = new List<AdditionalInfo>()
                        {
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "VISA"
                            },
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "BANCONTACT"
                            },
                            new AdditionalInfo()
                            {
                                Type = AdditionalInfoType.PaymentMethod,
                                Value = "MASTERCARD"
                            },
                            new AdditionalInfo()
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
                        Rooms = new List<Room>()
                        {
                            new Room()
                            {
                                Enabled = true,
                                Name = "Hoofdgebouw",
                                Height = 100,
                                Width = 500,
                                Spaces = new List<Space>()
                                {
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 1",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 2",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 3",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 4",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 5",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 6",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 7",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 8",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 9",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 10",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 11",
                                        MinPersons = 1,
                                        Persons = 8
                                    },
                                    new Space()
                                    {
                                        Enabled = true,
                                        Name = "Baan 12",
                                        MinPersons = 1,
                                        Persons = 8
                                    }
                                }
                            }
                        }
                    }
                }
            };
            context.Companies.Add(company2);
            context.SaveChanges();
        }
    }
}
