namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class integration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        USER_ID = c.Int(nullable: false, identity: true),
                        USER_NAME = c.String(nullable: false),
                        PASSWORD = c.String(nullable: false),
                        EMAILID = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.USER_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registrations");
        }
    }
}
