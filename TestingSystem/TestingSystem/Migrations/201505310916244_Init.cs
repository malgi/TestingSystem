namespace TestingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThematicFields",
                c => new
                    {
                        ThematicFieldId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentField_ThematicFieldId = c.Int(),
                    })
                .PrimaryKey(t => t.ThematicFieldId)
                .ForeignKey("dbo.ThematicFields", t => t.ParentField_ThematicFieldId)
                .Index(t => t.ParentField_ThematicFieldId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        NumberOfCorrectAnswers = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Explanation = c.String(),
                        ThematicFieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.ThematicFields", t => t.ThematicFieldId, cascadeDelete: true)
                .Index(t => t.ThematicFieldId);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        Question_QuestionId = c.Int(),
                        Question_QuestionId1 = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId1)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Question_QuestionId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Question_QuestionId1", "dbo.Questions");
            DropForeignKey("dbo.Questions", "ThematicFieldId", "dbo.ThematicFields");
            DropForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ThematicFields", "ParentField_ThematicFieldId", "dbo.ThematicFields");
            DropIndex("dbo.Answers", new[] { "Question_QuestionId1" });
            DropIndex("dbo.Answers", new[] { "Question_QuestionId" });
            DropIndex("dbo.Questions", new[] { "ThematicFieldId" });
            DropIndex("dbo.ThematicFields", new[] { "ParentField_ThematicFieldId" });
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.ThematicFields");
        }
    }
}
