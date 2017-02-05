namespace Leisurebooker.DataAccess.Tests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Value = c.String(),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.Branch_Id)
                .Index(t => t.Branch_Id);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress_Street = c.String(),
                        Adress_Number = c.String(),
                        Adress_Box = c.String(),
                        Adress_PostalCode = c.String(),
                        Adress_City = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.OpeningHour",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Byte(nullable: false),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.Branch_Id)
                .Index(t => t.Branch_Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.Branch_Id)
                .Index(t => t.Branch_Id);
            
            CreateTable(
                "dbo.Space",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Persons = c.Int(nullable: false),
                        MinPersons = c.Int(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VATNumber = c.String(),
                        Adress_Street = c.String(),
                        Adress_Number = c.String(),
                        Adress_Box = c.String(),
                        Adress_PostalCode = c.String(),
                        Adress_City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountOfPersons = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Cancelled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Public = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branch", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Room", "Branch_Id", "dbo.Branch");
            DropForeignKey("dbo.Space", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.OpeningHour", "Branch_Id", "dbo.Branch");
            DropForeignKey("dbo.AdditionalInfo", "Branch_Id", "dbo.Branch");
            DropIndex("dbo.Space", new[] { "Room_Id" });
            DropIndex("dbo.Room", new[] { "Branch_Id" });
            DropIndex("dbo.OpeningHour", new[] { "Branch_Id" });
            DropIndex("dbo.Branch", new[] { "CompanyId" });
            DropIndex("dbo.AdditionalInfo", new[] { "Branch_Id" });
            DropTable("dbo.Review");
            DropTable("dbo.Reservation");
            DropTable("dbo.Message");
            DropTable("dbo.Company");
            DropTable("dbo.Space");
            DropTable("dbo.Room");
            DropTable("dbo.OpeningHour");
            DropTable("dbo.Branch");
            DropTable("dbo.AdditionalInfo");
        }
    }
}
