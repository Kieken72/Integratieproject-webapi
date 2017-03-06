namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Byte(nullable: false),
                        Value = c.String(),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId);
            
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
                        Picture = c.String(),
                        Description = c.String(),
                        Email = c.String(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CityId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.CityId)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Picture = c.String(),
                        BranchId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        ManagerInBranch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.ManagerInBranch_Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.ManagerInBranch_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Read = c.Boolean(nullable: false),
                        Text = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        EventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Reservation", t => t.ReservationId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.ReservationId)
                .Index(t => t.BranchId)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        BranchId = c.Int(nullable: false),
                        MessageId = c.Int(),
                        ReservationId = c.Int(),
                        ReviewId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Message", t => t.MessageId)
                .ForeignKey("dbo.Reservation", t => t.ReservationId)
                .ForeignKey("dbo.Review", t => t.ReviewId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId)
                .Index(t => t.MessageId)
                .Index(t => t.ReservationId)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountOfPersons = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        SpaceId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        AccountId = c.String(nullable: false, maxLength: 128),
                        EventId = c.Int(),
                        Cancelled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Space", t => t.SpaceId)
                .Index(t => t.SpaceId)
                .Index(t => t.BranchId)
                .Index(t => t.AccountId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Result = c.Boolean(nullable: false),
                        Text = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Public = c.Boolean(nullable: false),
                        ReservationId = c.Int(nullable: false),
                        EventId = c.Int(),
                        BranchId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Reservation", t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.Id)
                .Index(t => t.EventId)
                .Index(t => t.BranchId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.OperationHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        FromTime = c.Time(nullable: false, precision: 7),
                        ToTime = c.Time(nullable: false, precision: 7),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        BranchId = c.String(nullable: false, maxLength: 128),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BranchId, t.AccountId })
                .ForeignKey("dbo.AspNetUsers", t => t.BranchId)
                .ForeignKey("dbo.Branch", t => t.AccountId)
                .Index(t => t.BranchId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Room", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Space", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Reservation", "SpaceId", "dbo.Space");
            DropForeignKey("dbo.Review", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Reservation", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.OperationHours", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Message", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Event", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.City", "HeadCityId", "dbo.City");
            DropForeignKey("dbo.Company", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservation", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Review", "Id", "dbo.Reservation");
            DropForeignKey("dbo.Review", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Review", "EventId", "dbo.Event");
            DropForeignKey("dbo.Event", "ReviewId", "dbo.Review");
            DropForeignKey("dbo.Message", "ReservationId", "dbo.Reservation");
            DropForeignKey("dbo.Reservation", "EventId", "dbo.Event");
            DropForeignKey("dbo.Event", "ReservationId", "dbo.Reservation");
            DropForeignKey("dbo.Message", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Message", "EventId", "dbo.Event");
            DropForeignKey("dbo.Event", "MessageId", "dbo.Message");
            DropForeignKey("dbo.AspNetUsers", "ManagerInBranch_Id", "dbo.Branch");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "AccountId", "dbo.Branch");
            DropForeignKey("dbo.Favorites", "BranchId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Company", "CityId", "dbo.City");
            DropForeignKey("dbo.Branch", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Branch", "CityId", "dbo.City");
            DropForeignKey("dbo.AdditionalInfo", "BranchId", "dbo.Branch");
            DropIndex("dbo.Favorites", new[] { "AccountId" });
            DropIndex("dbo.Favorites", new[] { "BranchId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Space", new[] { "RoomId" });
            DropIndex("dbo.Room", new[] { "BranchId" });
            DropIndex("dbo.OperationHours", new[] { "BranchId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "BranchId" });
            DropIndex("dbo.Review", new[] { "EventId" });
            DropIndex("dbo.Review", new[] { "Id" });
            DropIndex("dbo.Reservation", new[] { "EventId" });
            DropIndex("dbo.Reservation", new[] { "AccountId" });
            DropIndex("dbo.Reservation", new[] { "BranchId" });
            DropIndex("dbo.Reservation", new[] { "SpaceId" });
            DropIndex("dbo.Event", new[] { "ReviewId" });
            DropIndex("dbo.Event", new[] { "ReservationId" });
            DropIndex("dbo.Event", new[] { "MessageId" });
            DropIndex("dbo.Event", new[] { "BranchId" });
            DropIndex("dbo.Message", new[] { "EventId" });
            DropIndex("dbo.Message", new[] { "UserId" });
            DropIndex("dbo.Message", new[] { "BranchId" });
            DropIndex("dbo.Message", new[] { "ReservationId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "ManagerInBranch_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "BranchId" });
            DropIndex("dbo.Company", new[] { "Owner_Id" });
            DropIndex("dbo.Company", new[] { "CityId" });
            DropIndex("dbo.City", new[] { "HeadCityId" });
            DropIndex("dbo.Branch", new[] { "CompanyId" });
            DropIndex("dbo.Branch", new[] { "CityId" });
            DropIndex("dbo.AdditionalInfo", new[] { "BranchId" });
            DropTable("dbo.Favorites");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Space");
            DropTable("dbo.Room");
            DropTable("dbo.OperationHours");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Review");
            DropTable("dbo.Reservation");
            DropTable("dbo.Event");
            DropTable("dbo.Message");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Company");
            DropTable("dbo.City");
            DropTable("dbo.Branch");
            DropTable("dbo.AdditionalInfo");
        }
    }
}
