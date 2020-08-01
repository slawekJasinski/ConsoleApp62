namespace ConsoleApp62.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Cars",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        cars_id = c.Int(),
                        Stations_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cars", t => t.cars_id)
                .ForeignKey("dbo.Cities", t => t.Stations_id)
                .Index(t => t.cars_id)
                .Index(t => t.Stations_id);
            
          
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trains", "Stations_id", "dbo.Cities");
            DropForeignKey("dbo.Trains", "cars_id", "dbo.Cars");
            DropIndex("dbo.Trains", new[] { "Stations_id" });
            DropIndex("dbo.Trains", new[] { "cars_id" });
            DropTable("dbo.Cars");
            DropTable("dbo.Trains");
            DropTable("dbo.Tickets");
            DropTable("dbo.Cities");
        }
    }
}
