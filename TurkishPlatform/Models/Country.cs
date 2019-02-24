using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
		[Required]
		[MaxLength(100)]
		public string CountryName { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Activity> Activities { get; set; }
        public virtual List<Restaurant> Restaurants { get; set; }
        public virtual List<Tourism> Tourisms { get; set; }
        public virtual List<ForumCommentCategory> Topics { get; set; } 
        public virtual List<AdviceTopic> AdviceTopics { get; set; }

    }
}