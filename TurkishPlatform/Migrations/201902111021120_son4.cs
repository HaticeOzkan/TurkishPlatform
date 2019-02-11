namespace TurkishPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class son4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Remaining", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.ForumCommentCategories", "ImageUrl", c => c.String());
            DropColumn("dbo.Activities", "participation");
            DropColumn("dbo.Activities", "NumberofParticipations");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "NumberofParticipations", c => c.Int(nullable: false));
            AddColumn("dbo.Activities", "participation", c => c.Boolean(nullable: false));
            DropColumn("dbo.ForumCommentCategories", "ImageUrl");
            DropColumn("dbo.Activities", "Remaining");
        }
    }
}
