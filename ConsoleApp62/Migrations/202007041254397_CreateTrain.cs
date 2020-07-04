namespace ConsoleApp62.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trains");
        }
    }
}
