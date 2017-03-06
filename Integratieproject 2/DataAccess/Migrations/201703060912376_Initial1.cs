namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Favorites", new[] { "BranchId" });
            DropIndex("dbo.Favorites", new[] { "AccountId" });
            RenameColumn(table: "dbo.Favorites", name: "BranchId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Favorites", name: "AccountId", newName: "BranchId");
            RenameColumn(table: "dbo.Favorites", name: "__mig_tmp__0", newName: "AccountId");
            DropPrimaryKey("dbo.Favorites");
            AlterColumn("dbo.Favorites", "BranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Favorites", "AccountId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Favorites", new[] { "AccountId", "BranchId" });
            CreateIndex("dbo.Favorites", "AccountId");
            CreateIndex("dbo.Favorites", "BranchId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Favorites", new[] { "BranchId" });
            DropIndex("dbo.Favorites", new[] { "AccountId" });
            DropPrimaryKey("dbo.Favorites");
            AlterColumn("dbo.Favorites", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Favorites", "BranchId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Favorites", new[] { "BranchId", "AccountId" });
            RenameColumn(table: "dbo.Favorites", name: "AccountId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Favorites", name: "BranchId", newName: "AccountId");
            RenameColumn(table: "dbo.Favorites", name: "__mig_tmp__0", newName: "BranchId");
            CreateIndex("dbo.Favorites", "AccountId");
            CreateIndex("dbo.Favorites", "BranchId");
        }
    }
}
