namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Calendriers", "Subject");
            DropColumn("dbo.Calendriers", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calendriers", "Description", c => c.String());
            AddColumn("dbo.Calendriers", "Subject", c => c.String());
        }
    }
}
