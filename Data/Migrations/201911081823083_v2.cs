namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendriers", "Subject", c => c.String());
            AddColumn("dbo.Calendriers", "Description", c => c.String());
            AddColumn("dbo.Calendriers", "Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.Calendriers", "End", c => c.DateTime(nullable: false));
            AddColumn("dbo.Calendriers", "ThemeColor", c => c.String());
            AddColumn("dbo.Calendriers", "IsFullDay", c => c.Int(nullable: false));
            DropColumn("dbo.Calendriers", "disponibilite");
            DropColumn("dbo.Calendriers", "date");
            DropColumn("dbo.Calendriers", "heure");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calendriers", "heure", c => c.Single(nullable: false));
            AddColumn("dbo.Calendriers", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Calendriers", "disponibilite", c => c.String());
            DropColumn("dbo.Calendriers", "IsFullDay");
            DropColumn("dbo.Calendriers", "ThemeColor");
            DropColumn("dbo.Calendriers", "End");
            DropColumn("dbo.Calendriers", "Start");
            DropColumn("dbo.Calendriers", "Description");
            DropColumn("dbo.Calendriers", "Subject");
        }
    }
}
