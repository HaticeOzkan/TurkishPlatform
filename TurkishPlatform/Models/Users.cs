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
	public class Users
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
		public List<ForumComment> ForumComments { get; set; }
		public List<RestaurantComment> RestaurantComments { get; set; }
		public List<TourismComment> TourismComments { get; set; }
		public List<AdviceComment> AdviceComments { get; set; }
		public Location Location { get; set; }
	}

	[ComplexType]
	public class Location
	{
		public string Country { get; set; }
		public string City { get; set; }
	}
}