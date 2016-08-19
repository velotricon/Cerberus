namespace Cerberus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Translation", "Text", c => c.String());
            AddColumn("dbo.Translation", "TranslatedText", c => c.String());
            DropColumn("dbo.Translation", "CodeWord");
            DropColumn("dbo.Translation", "TranslationValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Translation", "TranslationValue", c => c.String());
            AddColumn("dbo.Translation", "CodeWord", c => c.String());
            DropColumn("dbo.Translation", "TranslatedText");
            DropColumn("dbo.Translation", "Text");
        }
    }
}
