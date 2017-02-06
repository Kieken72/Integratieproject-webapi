namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AdditionalInfo", new[] { "Branch_Id" });
            DropIndex("dbo.OpeningHour", new[] { "Branch_Id" });
            DropIndex("dbo.Room", new[] { "Branch_Id" });
            RenameColumn(table: "dbo.AdditionalInfo", name: "Branch_Id", newName: "BranchId");
            RenameColumn(table: "dbo.OpeningHour", name: "Branch_Id", newName: "BranchId");
            RenameColumn(table: "dbo.Room", name: "Branch_Id", newName: "BranchId");
            AlterColumn("dbo.AdditionalInfo", "BranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.OpeningHour", "BranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Room", "BranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Company", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "VATNumber", c => c.String(nullable: false));
            CreateIndex("dbo.AdditionalInfo", "BranchId");
            CreateIndex("dbo.OpeningHour", "BranchId");
            CreateIndex("dbo.Room", "BranchId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Room", new[] { "BranchId" });
            DropIndex("dbo.OpeningHour", new[] { "BranchId" });
            DropIndex("dbo.AdditionalInfo", new[] { "BranchId" });
            AlterColumn("dbo.Company", "VATNumber", c => c.String());
            AlterColumn("dbo.Company", "Name", c => c.String());
            AlterColumn("dbo.Room", "BranchId", c => c.Int());
            AlterColumn("dbo.OpeningHour", "BranchId", c => c.Int());
            AlterColumn("dbo.AdditionalInfo", "BranchId", c => c.Int());
            RenameColumn(table: "dbo.Room", name: "BranchId", newName: "Branch_Id");
            RenameColumn(table: "dbo.OpeningHour", name: "BranchId", newName: "Branch_Id");
            RenameColumn(table: "dbo.AdditionalInfo", name: "BranchId", newName: "Branch_Id");
            CreateIndex("dbo.Room", "Branch_Id");
            CreateIndex("dbo.OpeningHour", "Branch_Id");
            CreateIndex("dbo.AdditionalInfo", "Branch_Id");
        }
    }
}
