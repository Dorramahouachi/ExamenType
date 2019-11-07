namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "actualPost", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "actualPost");
        }
    }
}
