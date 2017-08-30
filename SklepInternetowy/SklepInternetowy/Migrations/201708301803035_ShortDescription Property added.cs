namespace SklepInternetowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDescriptionPropertyadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplement", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Supplement", "ShortDescription");
        }
    }
}
