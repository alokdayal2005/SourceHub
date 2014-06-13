namespace MovieReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FavoriteColor = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        DirectorName = c.String(),
                        ReleaseYear = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewerName = c.String(),
                        ReviewerComments = c.String(nullable: false, maxLength: 200),
                        ReviewerRating = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.MovieReviews", new[] { "MovieId" });
            DropForeignKey("dbo.MovieReviews", "MovieId", "dbo.Movies");
            DropTable("dbo.MovieReviews");
            DropTable("dbo.Movies");
            DropTable("dbo.UserProfile");
        }
    }
}
