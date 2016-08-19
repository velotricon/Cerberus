namespace Cerberus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Culture",
                c => new
                    {
                        CultureInfoCode = c.String(nullable: false, maxLength: 128),
                        Country = c.String(),
                        CountryCode = c.String(),
                        CountryCodeLong = c.String(),
                        Language = c.String(),
                        LangCode = c.String(),
                        LangCodeLong = c.String(),
                    })
                .PrimaryKey(t => t.CultureInfoCode);
            
            CreateTable(
                "dbo.Translation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeWord = c.String(),
                        Culture = c.String(),
                        TranslationValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Translation");
            DropTable("dbo.Culture");
        }
    }
}
