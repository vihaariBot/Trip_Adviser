namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class integration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RESTAURANT_ID = c.Int(nullable: false, identity: true),
                        RESTAURANT_NAME = c.String(nullable: false),
                        LOCATION_ID = c.Int(nullable: false),
                        ADRESS = c.String(nullable: false),
                        PRICE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RESTAURANT_ID)
                .ForeignKey("dbo.locations", t => t.LOCATION_ID, cascadeDelete: true)
                .Index(t => t.LOCATION_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "LOCATION_ID", "dbo.locations");
            DropIndex("dbo.Restaurants", new[] { "LOCATION_ID" });
            DropTable("dbo.Restaurants");
        }
    }
}
