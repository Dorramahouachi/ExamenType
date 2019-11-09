namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Correct = c.Boolean(),
                        QuestionID = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Questions", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.QuestionID);
            
            CreateTable(
                "dbo.Calendriers",
                c => new
                    {
                        CalendrierId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        ThemeColor = c.String(),
                        IsFullDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalendrierId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        login = c.String(maxLength: 15),
                        password = c.String(maxLength: 25),
                        name = c.String(),
                        lastname = c.String(),
                        birthDate = c.DateTime(),
                        Email = c.String(),
                        address = c.String(),
                        Skills = c.String(),
                        experience = c.String(),
                        bio = c.String(),
                        phoneContact = c.Long(),
                        picture = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Candidatures",
                c => new
                    {
                        candidatureId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        candidatureDate = c.DateTime(nullable: false),
                        etat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.candidatureId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        contactId1 = c.String(),
                        contactDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Entreprises",
                c => new
                    {
                        EntrepriseId = c.Int(nullable: false, identity: true),
                        Candidat_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.EntrepriseId)
                .ForeignKey("dbo.Users", t => t.Candidat_UserId)
                .Index(t => t.Candidat_UserId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Contenu = c.String(maxLength: 150),
                        Vue = c.Int(nullable: false),
                        DateSend = c.DateTime(nullable: false),
                        SendId = c.Int(),
                        RecieveId = c.Int(),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.Users", t => t.RecieveId)
                .ForeignKey("dbo.Users", t => t.SendId)
                .Index(t => t.SendId)
                .Index(t => t.RecieveId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Contenu = c.String(maxLength: 150),
                        DateComment = c.DateTime(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ReactComments",
                c => new
                    {
                        ReactCommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        TypeReact = c.String(),
                        CommentId = c.Int(),
                    })
                .PrimaryKey(t => t.ReactCommentId)
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.EntretienEnLignes",
                c => new
                    {
                        EntretienEnLigneId = c.Int(nullable: false, identity: true),
                        noteEntretien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntretienEnLigneId);
            
            CreateTable(
                "dbo.EntretienPhysiques",
                c => new
                    {
                        EntretienPhysiqueId = c.Int(nullable: false, identity: true),
                        DateEntretien = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntretienPhysiqueId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Contenu = c.String(maxLength: 150),
                        vue = c.Int(nullable: false),
                        DatePost = c.DateTime(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ReactPosts",
                c => new
                    {
                        ReactPostId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        TypeReact = c.String(),
                        PostId = c.Int(),
                    })
                .PrimaryKey(t => t.ReactPostId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.subscribes",
                c => new
                    {
                        subscribeId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        EntrepriseId = c.Int(),
                        subscribeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.subscribeId)
                .ForeignKey("dbo.Entreprises", t => t.EntrepriseId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EntrepriseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.subscribes", "UserId", "dbo.Users");
            DropForeignKey("dbo.subscribes", "EntrepriseId", "dbo.Entreprises");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReactPosts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReactPosts", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReactComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReactComments", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Chats", "SendId", "dbo.Users");
            DropForeignKey("dbo.Chats", "RecieveId", "dbo.Users");
            DropForeignKey("dbo.Entreprises", "Candidat_UserId", "dbo.Users");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Candidatures", "UserId", "dbo.Users");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.subscribes", new[] { "EntrepriseId" });
            DropIndex("dbo.subscribes", new[] { "UserId" });
            DropIndex("dbo.ReactPosts", new[] { "PostId" });
            DropIndex("dbo.ReactPosts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.ReactComments", new[] { "CommentId" });
            DropIndex("dbo.ReactComments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Chats", new[] { "RecieveId" });
            DropIndex("dbo.Chats", new[] { "SendId" });
            DropIndex("dbo.Entreprises", new[] { "Candidat_UserId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Candidatures", new[] { "UserId" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.subscribes");
            DropTable("dbo.ReactPosts");
            DropTable("dbo.Posts");
            DropTable("dbo.EntretienPhysiques");
            DropTable("dbo.EntretienEnLignes");
            DropTable("dbo.ReactComments");
            DropTable("dbo.Comments");
            DropTable("dbo.Chats");
            DropTable("dbo.Entreprises");
            DropTable("dbo.Contacts");
            DropTable("dbo.Candidatures");
            DropTable("dbo.Users");
            DropTable("dbo.Calendriers");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
