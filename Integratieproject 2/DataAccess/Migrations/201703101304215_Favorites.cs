namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favorites : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favorites", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.AspNetUsers", "ManagerInBranch_Id", "dbo.Branch");
            DropForeignKey("dbo.Event", "MessageId", "dbo.Message");
            DropForeignKey("dbo.Event", "ReservationId", "dbo.Reservation");
            DropForeignKey("dbo.Event", "ReviewId", "dbo.Review");
            DropForeignKey("dbo.Company", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branch");
            DropIndex("dbo.Company", new[] { "Owner_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "BranchId" });
            DropIndex("dbo.AspNetUsers", new[] { "ManagerInBranch_Id" });
            DropIndex("dbo.Event", new[] { "BranchId" });
            DropIndex("dbo.Event", new[] { "MessageId" });
            DropIndex("dbo.Event", new[] { "ReservationId" });
            DropIndex("dbo.Event", new[] { "ReviewId" });
            DropIndex("dbo.Favorites", new[] { "AccountId" });
            DropIndex("dbo.Favorites", new[] { "BranchId" });
            RenameColumn(table: "dbo.Event", name: "BranchId", newName: "Branch_Id");
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        BranchId = c.Int(nullable: false),
                        AccoundId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.BranchId, t.AccoundId });
            
            AddColumn("dbo.Event", "TypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Event", "Branch_Id", c => c.Int());
            CreateIndex("dbo.Event", "Branch_Id");
            DropColumn("dbo.Company", "Owner_Id");
            DropColumn("dbo.AspNetUsers", "BranchId");
            DropColumn("dbo.AspNetUsers", "ManagerInBranch_Id");
            DropColumn("dbo.Event", "MessageId");
            DropColumn("dbo.Event", "ReservationId");
            DropColumn("dbo.Event", "ReviewId");
            DropColumn("dbo.Event", "Discriminator");
            DropTable("dbo.Favorites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountId, t.BranchId });
            
            AddColumn("dbo.Event", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Event", "ReviewId", c => c.Int());
            AddColumn("dbo.Event", "ReservationId", c => c.Int());
            AddColumn("dbo.Event", "MessageId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ManagerInBranch_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "BranchId", c => c.Int());
            AddColumn("dbo.Company", "Owner_Id", c => c.String(maxLength: 128));
            DropIndex("dbo.Event", new[] { "Branch_Id" });
            AlterColumn("dbo.Event", "Branch_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Event", "TypeId");
            DropTable("dbo.Favorite");
            RenameColumn(table: "dbo.Event", name: "Branch_Id", newName: "BranchId");
            CreateIndex("dbo.Favorites", "BranchId");
            CreateIndex("dbo.Favorites", "AccountId");
            CreateIndex("dbo.Event", "ReviewId");
            CreateIndex("dbo.Event", "ReservationId");
            CreateIndex("dbo.Event", "MessageId");
            CreateIndex("dbo.Event", "BranchId");
            CreateIndex("dbo.AspNetUsers", "ManagerInBranch_Id");
            CreateIndex("dbo.AspNetUsers", "BranchId");
            CreateIndex("dbo.Company", "Owner_Id");
            AddForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branch", "Id");
            AddForeignKey("dbo.Company", "Owner_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Event", "ReviewId", "dbo.Review", "Id");
            AddForeignKey("dbo.Event", "ReservationId", "dbo.Reservation", "Id");
            AddForeignKey("dbo.Event", "MessageId", "dbo.Message", "Id");
            AddForeignKey("dbo.AspNetUsers", "ManagerInBranch_Id", "dbo.Branch", "Id");
            AddForeignKey("dbo.Favorites", "BranchId", "dbo.Branch", "Id");
            AddForeignKey("dbo.Favorites", "AccountId", "dbo.AspNetUsers", "Id");
        }
    }
}
