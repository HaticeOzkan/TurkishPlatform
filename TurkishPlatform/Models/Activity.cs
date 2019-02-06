using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string ImageURL { get; set; }
		[Required]
		[MaxLength(200)]
		public string Title { get; set; }
		[Required]
		[MaxLength(2000)]
		public string Content { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string Address { get; set; }
        public TimeSpan Remaining { get; set; }
		public Country Country { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public bool Permission { get; set; }
        public Activity()
        {
            Remaining = Date - DateTime.Now;
            Permission = false;
        }
       
    }
}