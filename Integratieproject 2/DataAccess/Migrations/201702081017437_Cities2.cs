namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cities2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropForeignKey("dbo.Address", "Id", "dbo.Company");
            DropForeignKey("dbo.Address", "Id", "dbo.Branch");
            DropIndex("dbo.Address", new[] { "Id" });
            DropIndex("dbo.Address", new[] { "CityId" });
            AddColumn("dbo.Branch", "Street", c => c.String());
            AddColumn("dbo.Branch", "Number", c => c.String());
            AddColumn("dbo.Branch", "Box", c => c.String());
            AddColumn("dbo.Branch", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Company", "Street", c => c.String());
            AddColumn("dbo.Company", "Number", c => c.String());
            AddColumn("dbo.Company", "Box", c => c.String());
            AddColumn("dbo.Company", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Branch", "CityId");
            CreateIndex("dbo.Company", "CityId");
            AddForeignKey("dbo.Branch", "CityId", "dbo.City", "Id");
            AddForeignKey("dbo.Company", "CityId", "dbo.City", "Id");
            DropTable("dbo.Address");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Company", "CityId", "dbo.City");
            DropForeignKey("dbo.Branch", "CityId", "dbo.City");
            DropIndex("dbo.Company", new[] { "CityId" });
            DropIndex("dbo.Branch", new[] { "CityId" });
            DropColumn("dbo.Company", "CityId");
            DropColumn("dbo.Company", "Box");
            DropColumn("dbo.Company", "Number");
            DropColumn("dbo.Company", "Street");
            DropColumn("dbo.Branch", "CityId");
            DropColumn("dbo.Branch", "Box");
            DropColumn("dbo.Branch", "Number");
            DropColumn("dbo.Branch", "Street");
            CreateIndex("dbo.Address", "CityId");
            CreateIndex("dbo.Address", "Id");
            AddForeignKey("dbo.Address", "Id", "dbo.Branch", "Id");
            AddForeignKey("dbo.Address", "Id", "dbo.Company", "Id");
            AddForeignKey("dbo.Address", "CityId", "dbo.City", "Id");
        }
    }
}
