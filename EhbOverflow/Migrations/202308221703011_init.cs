namespace EhbOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            Sql("INSERT INTO dbo.Categories (SubjectName) VALUES ('Android Studio')");
            Sql("INSERT INTO dbo.Categories (SubjectName) VALUES ('Java')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
