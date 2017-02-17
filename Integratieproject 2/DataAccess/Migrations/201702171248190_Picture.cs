namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Picture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branch", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Branch", "Picture");
        }
    }
}
