namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.hops",
                c => new
                    {
                        hopid = c.Int(nullable: false, identity: true),
                        routeid = c.Int(nullable: false),
                        hoplocation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.hopid);
            
            CreateTable(
                "dbo.locations",
                c => new
                    {
                        locationid = c.Int(nullable: false, identity: true),
                        locationname = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.locationid);
            
            CreateTable(
                "dbo.routes",
                c => new
                    {
                        routeid = c.Int(nullable: false, identity: true),
                        fromlocation = c.Int(nullable: false),
                        tolocation = c.Int(nullable: false),
                        modeoftravel = c.String(),
                    })
                .PrimaryKey(t => t.routeid)
                .ForeignKey("dbo.locations", t => t.fromlocation, cascadeDelete: false)
                .ForeignKey("dbo.locations", t => t.tolocation, cascadeDelete: true)
                .Index(t => t.fromlocation)
                .Index(t => t.tolocation);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.routes", "tolocation", "dbo.locations");
            DropForeignKey("dbo.routes", "fromlocation", "dbo.locations");
            DropIndex("dbo.routes", new[] { "tolocation" });
            DropIndex("dbo.routes", new[] { "fromlocation" });
            DropTable("dbo.routes");
            DropTable("dbo.locations");
            DropTable("dbo.hops");
        }
    }
}
