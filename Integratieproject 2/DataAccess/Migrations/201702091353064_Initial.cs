namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Picture = c.String(),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Street = c.String(),
                        Number = c.String(),
                        Box = c.String(),
                        CityId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CityId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.AdditionalInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Value = c.String(),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostalCode = c.String(),
                        Name = c.String(),
                        Province = c.String(),
                        HeadCityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.HeadCityId)
                .Index(t => t.HeadCityId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        VATNumber = c.String(nullable: false),
                        Street = c.String(),
                        Number = c.String(),
                        Box = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Text = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Reservation", t => t.ReservationId)
                .ForeignKey("dbo.Account", t => t.UserId)
                .Index(t => t.ReservationId)
                .Index(t => t.BranchId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OpeningHour",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Byte(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AmountOfPersons = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        SpaceId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        Cancelled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Review", t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Space", t => t.SpaceId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.Id)
                .Index(t => t.SpaceId)
                .Index(t => t.BranchId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.Boolean(nullable: false),
                        Text = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Public = c.Boolean(nullable: false),
                        BranchId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Account", t => t.UserId)
                .Index(t => t.BranchId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Space",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Persons = c.Int(nullable: false),
                        MinPersons = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.RoomId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountId, t.BranchId })
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.AccountId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "UserId", "dbo.Account");
            DropForeignKey("dbo.Reservation", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Message", "UserId", "dbo.Account");
            DropForeignKey("dbo.Favorites", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Favorites", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Room", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Space", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Reservation", "SpaceId", "dbo.Space");
            DropForeignKey("dbo.Review", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Reservation", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Reservation", "Id", "dbo.Review");
            DropForeignKey("dbo.Message", "ReservationId", "dbo.Reservation");
            DropForeignKey("dbo.OpeningHour", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Message", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.City", "HeadCityId", "dbo.City");
            DropForeignKey("dbo.Company", "CityId", "dbo.City");
            DropForeignKey("dbo.Branch", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Branch", "CityId", "dbo.City");
            DropForeignKey("dbo.AdditionalInfo", "BranchId", "dbo.Branch");
            DropIndex("dbo.Favorites", new[] { "BranchId" });
            DropIndex("dbo.Favorites", new[] { "AccountId" });
            DropIndex("dbo.Space", new[] { "RoomId" });
            DropIndex("dbo.Room", new[] { "BranchId" });
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "BranchId" });
            DropIndex("dbo.Reservation", new[] { "AccountId" });
            DropIndex("dbo.Reservation", new[] { "BranchId" });
            DropIndex("dbo.Reservation", new[] { "SpaceId" });
            DropIndex("dbo.Reservation", new[] { "Id" });
            DropIndex("dbo.OpeningHour", new[] { "BranchId" });
            DropIndex("dbo.Message", new[] { "UserId" });
            DropIndex("dbo.Message", new[] { "BranchId" });
            DropIndex("dbo.Message", new[] { "ReservationId" });
            DropIndex("dbo.Company", new[] { "CityId" });
            DropIndex("dbo.City", new[] { "HeadCityId" });
            DropIndex("dbo.AdditionalInfo", new[] { "BranchId" });
            DropIndex("dbo.Branch", new[] { "CompanyId" });
            DropIndex("dbo.Branch", new[] { "CityId" });
            DropTable("dbo.Favorites");
            DropTable("dbo.Space");
            DropTable("dbo.Room");
            DropTable("dbo.Review");
            DropTable("dbo.Reservation");
            DropTable("dbo.OpeningHour");
            DropTable("dbo.Message");
            DropTable("dbo.Company");
            DropTable("dbo.City");
            DropTable("dbo.AdditionalInfo");
            DropTable("dbo.Branch");
            DropTable("dbo.Account");
        }
    }
}
