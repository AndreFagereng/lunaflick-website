namespace PresentationLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Poster", c => c.String());
            AlterColumn("dbo.Movies", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Poster");
        }
    }
}
