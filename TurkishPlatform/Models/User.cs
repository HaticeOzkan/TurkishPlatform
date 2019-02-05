using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		public int Password { get; set; }
		[MaxLength(1000)]
		public string ImageURL { get; set; }
        public Country Country { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }
		public List<LocationComment> TourismComments { get; set; }
		public List<ForumComment> ForumComments { get; set; }
		public List<RestaurantComment> RestaurantComments { get; set; }
	}
    
}