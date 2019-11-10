namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            AlterColumn("dbo.Answers", "QuestionID", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "QuestionID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            AlterColumn("dbo.Answers", "QuestionID", c => c.Int());
            CreateIndex("dbo.Answers", "QuestionID");
        }
    }
}
