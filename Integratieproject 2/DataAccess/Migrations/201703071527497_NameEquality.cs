namespace Leisurebooker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameEquality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String());
            DropColumn("dbo.AspNetUsers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            DropColumn("dbo.AspNetUsers", "Lastname");
        }
    }
}
