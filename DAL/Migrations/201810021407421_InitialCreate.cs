namespace Oblig1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new 
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        Storyline = c.String(),
                        Director = c.String(),
                        Duration = c.String(),
                        ReleaseYear = c.String(),
                        Price = c.Int(nullable: false),
                        Stars = c.Double(nullable: false),
                        ContentRating = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        OrderLineId = c.Int(nullable: false, identity: true),
                        Movie_MovieId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderLineId)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Movie_MovieId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.Binary(),
                        Salt = c.Binary(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PostalAddress_ZipCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.PostalAddresses", t => t.PostalAddress_ZipCode)
                .Index(t => t.PostalAddress_ZipCode);
            
            CreateTable(
                "dbo.PostalAddresses",
                c => new
                    {
                        ZipCode = c.String(nullable: false, maxLength: 128),
                        PostalArea = c.String(),
                    })
                .PrimaryKey(t => t.ZipCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PostalAddress_ZipCode", "dbo.PostalAddresses");
            DropForeignKey("dbo.Orders", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.OrderLines", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderLines", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.Users", new[] { "PostalAddress_ZipCode" });
            DropIndex("dbo.OrderLines", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderLines", new[] { "Movie_MovieId" });
            DropIndex("dbo.Orders", new[] { "User_UserId" });
            DropTable("dbo.PostalAddresses");
            DropTable("dbo.Users");
            DropTable("dbo.OrderLines");
            DropTable("dbo.Orders");
            DropTable("dbo.Movies");
        }
    }
}
