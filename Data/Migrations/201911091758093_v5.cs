namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            AddForeignKey("dbo.Answers", "QuestionID", "dbo.Questions", "QuestionID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            AddForeignKey("dbo.Answers", "QuestionID", "dbo.Questions", "QuestionID");
        }
    }
}
