namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drink",
                c => new
                    {
                        DrinkId = c.Int(nullable: false, identity: true),
                        DrinkType = c.Int(nullable: false),
                        UseMug = c.Boolean(nullable: false),
                        SugarQuantity = c.Int(nullable: false),
                        BadgeId = c.String(nullable: false),
                        DrinkDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.DrinkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drink");
        }
    }
}
