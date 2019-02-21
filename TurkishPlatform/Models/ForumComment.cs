using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class ForumComment
    {
		[Key]
		public int CommentId { get; set; }
		[Column(TypeName = "text")]
		[Required]
		public string Content { get; set; }
        [NotMapped]
		public DateTime Date { get; set; }
		[ForeignKey("UserId")]
		public virtual User ByUser { get; set; }
		public int UserId { get; set; }
		public ForumCommentTopic CommentTopic { get; set; }
		[ForeignKey("CommentTopic")]
		public int CommentTopicId { get; set; }

        public ForumComment()
		{
          
			Date = DateTime.Now;
		}
	}

	public class ForumCommentTopic
	{
		[Key]
		public int TopicId { get; set; }
		[Required]
		[MaxLength(200)]
		public string TopicTitle { get; set; }
		public virtual List<ForumComment> ForumComments { get; set; }
		public ForumTopicTitle ForumTopicTitle { get; set; }
		[ForeignKey("ForumTopicTitle")]
		public int ForumTopicTitleId{ get; set; }
       
       
	}
    public class ForumTopicTitle
    {
        [Key]
        public int TitleId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
        public virtual List<ForumCommentTopic> CommentTopics { get; set; }
        public ForumCommentCategory CommentCategory { get; set; }
        [ForeignKey("CommentCategory")]
        public int CommentCategoryId { get; set; }


    }

	public class ForumCommentCategory
	{
		[Key]
		public int CategoryId { get; set; }
		[Required]
		[MaxLength(200)]
		public string CategoryName { get; set; }
		public virtual List<ForumTopicTitle> ForumTopicTitles { get; set; }
		public Country Country { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }

	}

}