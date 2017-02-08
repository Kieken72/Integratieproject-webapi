namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Street = c.String(),
                        Number = c.String(),
                        Box = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Company", t => t.Id)
                .ForeignKey("dbo.Branch", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CityId);
            
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
            
            DropColumn("dbo.Branch", "Adress_Street");
            DropColumn("dbo.Branch", "Adress_Number");
            DropColumn("dbo.Branch", "Adress_Box");
            DropColumn("dbo.Branch", "Adress_PostalCode");
            DropColumn("dbo.Branch", "Adress_City");
            DropColumn("dbo.Branch", "Adress_Country");
            DropColumn("dbo.Company", "Adress_Street");
            DropColumn("dbo.Company", "Adress_Number");
            DropColumn("dbo.Company", "Adress_Box");
            DropColumn("dbo.Company", "Adress_PostalCode");
            DropColumn("dbo.Company", "Adress_City");
            DropColumn("dbo.Company", "Adress_Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "Adress_Country", c => c.String());
            AddColumn("dbo.Company", "Adress_City", c => c.String());
            AddColumn("dbo.Company", "Adress_PostalCode", c => c.String());
            AddColumn("dbo.Company", "Adress_Box", c => c.String());
            AddColumn("dbo.Company", "Adress_Number", c => c.String());
            AddColumn("dbo.Company", "Adress_Street", c => c.String());
            AddColumn("dbo.Branch", "Adress_Country", c => c.String());
            AddColumn("dbo.Branch", "Adress_City", c => c.String());
            AddColumn("dbo.Branch", "Adress_PostalCode", c => c.String());
            AddColumn("dbo.Branch", "Adress_Box", c => c.String());
            AddColumn("dbo.Branch", "Adress_Number", c => c.String());
            AddColumn("dbo.Branch", "Adress_Street", c => c.String());
            DropForeignKey("dbo.Address", "Id", "dbo.Branch");
            DropForeignKey("dbo.Address", "Id", "dbo.Company");
            DropForeignKey("dbo.City", "HeadCityId", "dbo.City");
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropIndex("dbo.City", new[] { "HeadCityId" });
            DropIndex("dbo.Address", new[] { "CityId" });
            DropIndex("dbo.Address", new[] { "Id" });
            DropTable("dbo.City");
            DropTable("dbo.Address");
        }
    }
}
