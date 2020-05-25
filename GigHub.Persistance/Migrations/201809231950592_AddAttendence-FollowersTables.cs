namespace FullStackCourse1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendenceFollowersTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtistFollowers",
                c => new
                    {
                        ArtistId = c.String(nullable: false, maxLength: 128),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.FollowerId })
                .ForeignKey("dbo.AspNetUsers", t => t.ArtistId)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.FollowerId);
            
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        GigId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GigId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Gigs", t => t.GigId)
                .Index(t => t.GigId)
                .Index(t => t.AttendeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "GigId", "dbo.Gigs");
            DropForeignKey("dbo.Attendences", "AttendeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArtistFollowers", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArtistFollowers", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendences", new[] { "AttendeeId" });
            DropIndex("dbo.Attendences", new[] { "GigId" });
            DropIndex("dbo.ArtistFollowers", new[] { "FollowerId" });
            DropIndex("dbo.ArtistFollowers", new[] { "ArtistId" });
            DropTable("dbo.Attendences");
            DropTable("dbo.ArtistFollowers");
        }
    }
}
