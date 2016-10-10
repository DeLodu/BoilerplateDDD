namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ta_Knb_Status",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        Omschrijving = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.UID);
            
            AddColumn("dbo.ta_Knb_Taak", "StatusUID", c => c.Guid(nullable: false));
            AlterColumn("dbo.ta_Knb_Taak", "OmschrijvingKort", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.ta_Knb_Taak", "StatusUID");
            AddForeignKey("dbo.ta_Knb_Taak", "StatusUID", "dbo.ta_Knb_Status", "UID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ta_Knb_Taak", "StatusUID", "dbo.ta_Knb_Status");
            DropIndex("dbo.ta_Knb_Taak", new[] { "StatusUID" });
            AlterColumn("dbo.ta_Knb_Taak", "OmschrijvingKort", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.ta_Knb_Taak", "StatusUID");
            DropTable("dbo.ta_Knb_Status");
        }
    }
}
