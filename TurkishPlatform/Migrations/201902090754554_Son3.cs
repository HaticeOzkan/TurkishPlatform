namespace TurkishPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Son3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ForumCommentTopics", "CommentCategoryId", "dbo.ForumCommentCategories");
            DropIndex("dbo.ForumCommentTopics", new[] { "CommentCategoryId" });
            CreateTable(
                "dbo.ForumTopicTitles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                        CommentCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TitleId)
                .ForeignKey("dbo.ForumCommentCategories", t => t.CommentCategoryId, cascadeDelete: true)
                .Index(t => t.CommentCategoryId);
            
            AddColumn("dbo.ForumCommentTopics", "ForumTopicTitleId", c => c.Int(nullable: false));
            CreateIndex("dbo.ForumCommentTopics", "ForumTopicTitleId");
            AddForeignKey("dbo.ForumCommentTopics", "ForumTopicTitleId", "dbo.ForumTopicTitles", "TitleId", cascadeDelete: true);
            DropColumn("dbo.ForumCommentTopics", "CommentCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ForumCommentTopics", "CommentCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ForumCommentTopics", "ForumTopicTitleId", "dbo.ForumTopicTitles");
            DropForeignKey("dbo.ForumTopicTitles", "CommentCategoryId", "dbo.ForumCommentCategories");
            DropIndex("dbo.ForumTopicTitles", new[] { "CommentCategoryId" });
            DropIndex("dbo.ForumCommentTopics", new[] { "ForumTopicTitleId" });
            DropColumn("dbo.ForumCommentTopics", "ForumTopicTitleId");
            DropTable("dbo.ForumTopicTitles");
            CreateIndex("dbo.ForumCommentTopics", "CommentCategoryId");
            AddForeignKey("dbo.ForumCommentTopics", "CommentCategoryId", "dbo.ForumCommentCategories", "CategoryId", cascadeDelete: true);
        }
    }
}
