namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11_22 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Space", new[] { "Room_Id" });
            RenameColumn(table: "dbo.Space", name: "Room_Id", newName: "RoomId");
            AlterColumn("dbo.Branch", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Branch", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Space", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Space", "RoomId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Space", new[] { "RoomId" });
            AlterColumn("dbo.Space", "RoomId", c => c.Int());
            AlterColumn("dbo.Branch", "Email", c => c.String());
            AlterColumn("dbo.Branch", "Name", c => c.String());
            RenameColumn(table: "dbo.Space", name: "RoomId", newName: "Room_Id");
            CreateIndex("dbo.Space", "Room_Id");
        }
    }
}
