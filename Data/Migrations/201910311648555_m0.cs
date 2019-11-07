namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendriers",
                c => new
                    {
                        CalendrierId = c.Int(nullable: false, identity: true),
                        disponibilite = c.String(),
                        date = c.DateTime(nullable: false),
                        heure = c.Single(nullable: false),
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
                        etat = c.String(),
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
                "dbo.Entretiens",
                c => new
                    {
                        EntretienId = c.Int(nullable: false, identity: true),
                        EntretienEnLigneId = c.Int(),
                        noteEntretien = c.Int(),
                        QuestionId = c.Int(),
                        EntretienPhysiqueId = c.Int(),
                        DateEntretien = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EntretienId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Questions = c.String(),
                        NoteQuestion = c.Int(nullable: false),
                        ReponseCorrect = c.String(),
                        ReponseIncorrect1 = c.String(),
                        ReponseIncorrect2 = c.String(),
                        EntretienEnLigne_EntretienId = c.Int(),
                        EntretienEnLigne_EntretienId1 = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Entretiens", t => t.EntretienEnLigne_EntretienId)
                .ForeignKey("dbo.Entretiens", t => t.EntretienEnLigne_EntretienId1)
                .Index(t => t.EntretienEnLigne_EntretienId)
                .Index(t => t.EntretienEnLigne_EntretienId1);
            
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

            CreateTable(
                "dbo.Claim",
                c => new
                {
                    ClaimId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    DateClaim = c.DateTime(),
                })
                .PrimaryKey(t => t.ClaimId);

            CreateTable(
                "dbo.Payment",
                c => new
                {
                    PaymentId = c.Int(nullable: false, identity: true),
                    Amount = c.Double(),
                    DatePayment = c.DateTime(),
                })
                .PrimaryKey(t => t.PaymentId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.subscribes", "UserId", "dbo.Users");
            DropForeignKey("dbo.subscribes", "EntrepriseId", "dbo.Entreprises");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReactPosts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReactPosts", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Entretiens", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "EntretienEnLigne_EntretienId1", "dbo.Entretiens");
            DropForeignKey("dbo.Questions", "EntretienEnLigne_EntretienId", "dbo.Entretiens");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReactComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReactComments", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Chats", "SendId", "dbo.Users");
            DropForeignKey("dbo.Chats", "RecieveId", "dbo.Users");
            DropForeignKey("dbo.Entreprises", "Candidat_UserId", "dbo.Users");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Candidatures", "UserId", "dbo.Users");
            DropIndex("dbo.subscribes", new[] { "EntrepriseId" });
            DropIndex("dbo.subscribes", new[] { "UserId" });
            DropIndex("dbo.ReactPosts", new[] { "PostId" });
            DropIndex("dbo.ReactPosts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "EntretienEnLigne_EntretienId1" });
            DropIndex("dbo.Questions", new[] { "EntretienEnLigne_EntretienId" });
            DropIndex("dbo.Entretiens", new[] { "QuestionId" });
            DropIndex("dbo.ReactComments", new[] { "CommentId" });
            DropIndex("dbo.ReactComments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Chats", new[] { "RecieveId" });
            DropIndex("dbo.Chats", new[] { "SendId" });
            DropIndex("dbo.Entreprises", new[] { "Candidat_UserId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Candidatures", new[] { "UserId" });
            DropTable("dbo.subscribes");
            DropTable("dbo.ReactPosts");
            DropTable("dbo.Posts");
            DropTable("dbo.Questions");
            DropTable("dbo.Entretiens");
            DropTable("dbo.ReactComments");
            DropTable("dbo.Comments");
            DropTable("dbo.Chats");
            DropTable("dbo.Entreprises");
            DropTable("dbo.Contacts");
            DropTable("dbo.Candidatures");
            DropTable("dbo.Users");
            DropTable("dbo.Calendriers");
        }
    }
}
