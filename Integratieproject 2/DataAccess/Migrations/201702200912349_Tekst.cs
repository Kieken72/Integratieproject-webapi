namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tekst : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branch", "Description", c => c.String());
            AlterColumn("dbo.AdditionalInfo", "Type", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdditionalInfo", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Branch", "Description");
        }
    }
}
