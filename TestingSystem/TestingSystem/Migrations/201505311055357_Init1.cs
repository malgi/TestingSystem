namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestSchemes",
                c => new
                    {
                        TestSchemeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Time = c.Int(nullable: false),
                        AvailableFrom = c.DateTime(nullable: false),
                        AvailableTo = c.DateTime(nullable: false),
                        NumberOfQuestions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestSchemeId);
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        StudentGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        TestScheme_TestSchemeId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentGroupId)
                .ForeignKey("dbo.TestSchemes", t => t.TestScheme_TestSchemeId)
                .Index(t => t.TestScheme_TestSchemeId);
            
            AddColumn("dbo.ThematicFields", "TestScheme_TestSchemeId", c => c.Int());
            AddColumn("dbo.Questions", "TestScheme_TestSchemeId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "StudentGroup_StudentGroupId", c => c.Int());
            CreateIndex("dbo.ThematicFields", "TestScheme_TestSchemeId");
            CreateIndex("dbo.Questions", "TestScheme_TestSchemeId");
            CreateIndex("dbo.AspNetUsers", "StudentGroup_StudentGroupId");
            AddForeignKey("dbo.ThematicFields", "TestScheme_TestSchemeId", "dbo.TestSchemes", "TestSchemeId");
            AddForeignKey("dbo.Questions", "TestScheme_TestSchemeId", "dbo.TestSchemes", "TestSchemeId");
            AddForeignKey("dbo.AspNetUsers", "StudentGroup_StudentGroupId", "dbo.StudentGroups", "StudentGroupId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGroups", "TestScheme_TestSchemeId", "dbo.TestSchemes");
            DropForeignKey("dbo.AspNetUsers", "StudentGroup_StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.Questions", "TestScheme_TestSchemeId", "dbo.TestSchemes");
            DropForeignKey("dbo.ThematicFields", "TestScheme_TestSchemeId", "dbo.TestSchemes");
            DropIndex("dbo.AspNetUsers", new[] { "StudentGroup_StudentGroupId" });
            DropIndex("dbo.StudentGroups", new[] { "TestScheme_TestSchemeId" });
            DropIndex("dbo.Questions", new[] { "TestScheme_TestSchemeId" });
            DropIndex("dbo.ThematicFields", new[] { "TestScheme_TestSchemeId" });
            DropColumn("dbo.AspNetUsers", "StudentGroup_StudentGroupId");
            DropColumn("dbo.Questions", "TestScheme_TestSchemeId");
            DropColumn("dbo.ThematicFields", "TestScheme_TestSchemeId");
            DropTable("dbo.StudentGroups");
            DropTable("dbo.TestSchemes");
        }
    }
}
