namespace TurkishPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Son : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdviceTopics", "AdviceId", "dbo.Advices");
            DropIndex("dbo.AdviceTopics", new[] { "AdviceId" });
            AddColumn("dbo.Activities", "Share", c => c.Boolean(nullable: false));
            AddColumn("dbo.Advices", "AdviceTopicID", c => c.Int(nullable: false));
            AddColumn("dbo.Advices", "AdviceTopic_CategoryId", c => c.String(maxLength: 128));
            AddColumn("dbo.RestaurantComments", "Share", c => c.Boolean(nullable: false));
            AddColumn("dbo.ForumComments", "Share", c => c.Boolean(nullable: false));
            AddColumn("dbo.LocationComments", "Share", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Advices", "AdviceTopic_CategoryId");
            AddForeignKey("dbo.Advices", "AdviceTopic_CategoryId", "dbo.AdviceTopics", "CategoryId");
            DropColumn("dbo.AdviceTopics", "AdviceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdviceTopics", "AdviceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Advices", "AdviceTopic_CategoryId", "dbo.AdviceTopics");
            DropIndex("dbo.Advices", new[] { "AdviceTopic_CategoryId" });
            DropColumn("dbo.LocationComments", "Share");
            DropColumn("dbo.ForumComments", "Share");
            DropColumn("dbo.RestaurantComments", "Share");
            DropColumn("dbo.Advices", "AdviceTopic_CategoryId");
            DropColumn("dbo.Advices", "AdviceTopicID");
            DropColumn("dbo.Activities", "Share");
            CreateIndex("dbo.AdviceTopics", "AdviceId");
            AddForeignKey("dbo.AdviceTopics", "AdviceId", "dbo.Advices", "AdviceId", cascadeDelete: true);
        }
    }
}
