namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationByUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "ReservationByUser", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservation", "ReservationByUser");
        }
    }
}
