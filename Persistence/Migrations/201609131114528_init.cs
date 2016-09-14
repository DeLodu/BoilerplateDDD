namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ta_App_Gebruiker",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        Naam = c.String(maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 50),
                        Salt = c.String(maxLength: 100),
                        PasswordHash = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.UID);
            
            CreateTable(
                "dbo.ta_App_LogItem",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        Melding = c.String(nullable: false, maxLength: 150),
                        Datum = c.DateTime(nullable: false),
                        LoginNaam = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ta_App_LogItem");
            DropTable("dbo.ta_App_Gebruiker");
        }
    }
}
