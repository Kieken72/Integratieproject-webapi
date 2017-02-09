namespace Leisurebooker.DataAccess.Tests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OpeningHour", newName: "OperationHours");
            AddColumn("dbo.OperationHours", "FromTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.OperationHours", "ToTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.OperationHours", "Day", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OperationHours", "Day", c => c.Byte(nullable: false));
            DropColumn("dbo.OperationHours", "ToTime");
            DropColumn("dbo.OperationHours", "FromTime");
            RenameTable(name: "dbo.OperationHours", newName: "OpeningHour");
        }
    }
}
