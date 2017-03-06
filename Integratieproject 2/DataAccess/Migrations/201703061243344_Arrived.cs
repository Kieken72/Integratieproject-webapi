namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arrived : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "Arrived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservation", "Arrived");
        }
    }
}
