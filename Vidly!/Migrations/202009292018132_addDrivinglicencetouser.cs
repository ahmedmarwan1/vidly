namespace Vidly_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDrivinglicencetouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
    }
}
