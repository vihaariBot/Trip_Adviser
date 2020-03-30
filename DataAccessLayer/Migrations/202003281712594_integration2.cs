namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class integration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lodges",
                c => new
                    {
                        LODGE_ID = c.Int(nullable: false, identity: true),
                        LOCATION_ID = c.Int(nullable: false),
                        LODGE_NAME = c.String(),
                        LODGE_ADD = c.String(),
                        PRICE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LODGE_ID)
                .ForeignKey("dbo.locations", t => t.LOCATION_ID, cascadeDelete: true)
                .Index(t => t.LOCATION_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lodges", "LOCATION_ID", "dbo.locations");
            DropIndex("dbo.Lodges", new[] { "LOCATION_ID" });
            DropTable("dbo.Lodges");
        }
    }
}
