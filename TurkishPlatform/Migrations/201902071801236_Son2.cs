namespace TurkishPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Son2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantComments", "Permission", c => c.Boolean(nullable: false));
            AddColumn("dbo.ForumComments", "Permission", c => c.Boolean(nullable: false));
            AddColumn("dbo.LocationComments", "Permission", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Activities", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Activities", "Share");
            DropColumn("dbo.RestaurantComments", "Share");
            DropColumn("dbo.ForumComments", "Share");
            DropColumn("dbo.LocationComments", "Share");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocationComments", "Share", c => c.Boolean(nullable: false));
            AddColumn("dbo.ForumComments", "Share", c => c.Boolean(nullable: false));
            AddColumn("dbo.RestaurantComments", "Share", c => c.Boolean(nullable: false));
            AddColumn("dbo.Activities", "Share", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Activities", "Address", c => c.String());
            DropColumn("dbo.LocationComments", "Permission");
            DropColumn("dbo.ForumComments", "Permission");
            DropColumn("dbo.RestaurantComments", "Permission");
        }
    }
}
