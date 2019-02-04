using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Column(TypeName = "text")]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("UserId")]
        public User ByUser { get; set; }
        public int UserId { get; set; }

        public Comment()
        {
            Date = DateTime.Now;
        }
    }

    public class AdviceComment : Comment { }

    public class TourismComment : Comment { }

    public class RestaurantComment : Comment { }

    public class TopicComment : Comment { }
    
}