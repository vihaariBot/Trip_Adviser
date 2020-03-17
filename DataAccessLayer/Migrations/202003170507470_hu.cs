namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.placestovisits",
                c => new
                    {
                        ptvid = c.Int(nullable: false, identity: true),
                        placename = c.String(),
                        locationid = c.Int(nullable: false),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.ptvid)
                .ForeignKey("dbo.locations", t => t.locationid, cascadeDelete: true)
                .Index(t => t.locationid);
            
            CreateTable(
                "dbo.ratings",
                c => new
                    {
                        ratingid = c.Int(nullable: false, identity: true),
                        itemid = c.Int(nullable: false),
                        itemtype = c.String(),
                        ratedby = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ratingid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.placestovisits", "locationid", "dbo.locations");
            DropIndex("dbo.placestovisits", new[] { "locationid" });
            DropTable("dbo.ratings");
            DropTable("dbo.placestovisits");
        }
    }
}
