using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
	public enum Gender
	{
		Female,
		Male
	}
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(200)]
        [Required]
        public string NameSurname { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        public int CountryNo { get; set; }
        public virtual List<LocationComment> TourismComments { get; set; }
        public virtual List<ForumComment> ForumComments { get; set; }
        public virtual List<RestaurantComment> RestaurantComments { get; set; }
     
        public virtual List<Contact> Contacts { get; set; }
        public virtual List<Activity> Activities { get; set; }
        public string ImageURL { get; set; }
        public double Score { get; set; }


    }
    
}