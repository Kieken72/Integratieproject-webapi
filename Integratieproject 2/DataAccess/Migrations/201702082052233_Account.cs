namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Picture");
        }
    }
}
