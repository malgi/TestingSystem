namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        TestResultId = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        Student_Id = c.String(maxLength: 128),
                        TestScheme_TestSchemeId = c.Int(),
                    })
                .PrimaryKey(t => t.TestResultId)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .ForeignKey("dbo.TestSchemes", t => t.TestScheme_TestSchemeId)
                .Index(t => t.Student_Id)
                .Index(t => t.TestScheme_TestSchemeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "TestScheme_TestSchemeId", "dbo.TestSchemes");
            DropForeignKey("dbo.TestResults", "Student_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TestResults", new[] { "TestScheme_TestSchemeId" });
            DropIndex("dbo.TestResults", new[] { "Student_Id" });
            DropTable("dbo.TestResults");
        }
    }
}
