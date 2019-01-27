namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drink", "DrinkDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drink", "DrinkDate", c => c.DateTime(storeType: "date"));
        }
    }
}
