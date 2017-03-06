namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationSpace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Space", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Space", "X", c => c.Int(nullable: false));
            AddColumn("dbo.Space", "Y", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Space", "Y");
            DropColumn("dbo.Space", "X");
            DropColumn("dbo.Space", "Type");
        }
    }
}
