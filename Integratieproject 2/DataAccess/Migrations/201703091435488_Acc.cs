namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Acc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reservation", "User_Id");
            AddForeignKey("dbo.Reservation", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservation", new[] { "User_Id" });
            DropColumn("dbo.Reservation", "User_Id");
        }
    }
}
