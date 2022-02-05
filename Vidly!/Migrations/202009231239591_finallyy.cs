namespace Vidly_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finallyy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
