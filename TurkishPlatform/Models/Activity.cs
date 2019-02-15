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
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        [Required]
        public string Address { get; set; }
       
         
        public virtual Country Country { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
       
        public virtual User User { get; set; }
        public virtual List<User> Participants { get; set; }
        public bool Permission { get; set; }
      
        public Activity()
        {
         

            Permission = false;
            Participation = false;


        }
        public bool Participation { get; set; }
       public int NumberofParticipations { get; set; }


    }
}