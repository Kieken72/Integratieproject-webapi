namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1200 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "ReservationId", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "BranchId", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Reservation", "SpaceId", c => c.Int(nullable: false));
            AddColumn("dbo.Reservation", "BranchId", c => c.Int(nullable: false));
            AddColumn("dbo.Reservation", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Reservation", "Review_Id", c => c.Int());
            AddColumn("dbo.Review", "ReservationId", c => c.Int(nullable: false));
            AddColumn("dbo.Review", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Message", "ReservationId");
            CreateIndex("dbo.Message", "BranchId");
            CreateIndex("dbo.Reservation", "SpaceId");
            CreateIndex("dbo.Reservation", "BranchId");
            CreateIndex("dbo.Reservation", "Review_Id");
            CreateIndex("dbo.Review", "BranchId");
            AddForeignKey("dbo.Message", "BranchId", "dbo.Branch", "Id");
            AddForeignKey("dbo.Message", "ReservationId", "dbo.Reservation", "Id");
            AddForeignKey("dbo.Reservation", "Review_Id", "dbo.Review", "Id");
            AddForeignKey("dbo.Reservation", "BranchId", "dbo.Branch", "Id");
            AddForeignKey("dbo.Review", "BranchId", "dbo.Branch", "Id");
            AddForeignKey("dbo.Reservation", "SpaceId", "dbo.Space", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "SpaceId", "dbo.Space");
            DropForeignKey("dbo.Review", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Reservation", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Reservation", "Review_Id", "dbo.Review");
            DropForeignKey("dbo.Message", "ReservationId", "dbo.Reservation");
            DropForeignKey("dbo.Message", "BranchId", "dbo.Branch");
            DropIndex("dbo.Review", new[] { "BranchId" });
            DropIndex("dbo.Reservation", new[] { "Review_Id" });
            DropIndex("dbo.Reservation", new[] { "BranchId" });
            DropIndex("dbo.Reservation", new[] { "SpaceId" });
            DropIndex("dbo.Message", new[] { "BranchId" });
            DropIndex("dbo.Message", new[] { "ReservationId" });
            DropColumn("dbo.Review", "BranchId");
            DropColumn("dbo.Review", "ReservationId");
            DropColumn("dbo.Reservation", "Review_Id");
            DropColumn("dbo.Reservation", "UserId");
            DropColumn("dbo.Reservation", "BranchId");
            DropColumn("dbo.Reservation", "SpaceId");
            DropColumn("dbo.Message", "UserId");
            DropColumn("dbo.Message", "BranchId");
            DropColumn("dbo.Message", "ReservationId");
        }
    }
}
