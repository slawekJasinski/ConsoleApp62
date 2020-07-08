﻿namespace ConsoleApp62.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCity : DbMigration
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

        }

        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
