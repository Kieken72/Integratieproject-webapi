namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branch", "Adress_Country", c => c.String());
            AddColumn("dbo.Company", "Adress_Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "Adress_Country");
            DropColumn("dbo.Branch", "Adress_Country");
        }
    }
}
