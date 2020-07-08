﻿namespace ConsoleApp62.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.Tickets",
    c => new
    {
        id = c.Int(nullable: false, identity: true),
    })
    .PrimaryKey(t => t.id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
