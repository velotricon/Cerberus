namespace Cerberus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Translation", "LangCode", c => c.String());
            DropColumn("dbo.Translation", "Culture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Translation", "Culture", c => c.String());
            DropColumn("dbo.Translation", "LangCode");
        }
    }
}
