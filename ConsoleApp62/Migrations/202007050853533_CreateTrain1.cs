namespace ConsoleApp62.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrain1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trains", "RelationID", c => c.Int(nullable: false));
            AddColumn("dbo.Trains", "CarsID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trains", "CarsID");
            DropColumn("dbo.Trains", "RelationID");
        }
    }
}
