namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nshow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "NoShow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservation", "NoShow");
        }
    }
}
