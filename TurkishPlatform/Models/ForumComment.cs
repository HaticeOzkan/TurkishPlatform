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
		public DateTime Date { get; set; }
		[ForeignKey("UserId")]
		public User ByUser { get; set; }
		public int UserId { get; set; }
		public ForumCommentTopic CommentTopic { get; set; }
		[ForeignKey("CommentTopic")]
		public int CommentTopicId { get; set; }
        public bool Share { get; set; }

		public ForumComment()
		{
            Share = false;
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
		public List<ForumComment> ForumComments { get; set; }
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
		public virtual List<ForumCommentTopic> CommentTopics { get; set; }
		public Country Country { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }

	}

}