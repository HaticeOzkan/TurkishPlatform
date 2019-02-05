﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class Restaurant
    {
		[Key]
		public int RestaurantId { get; set; }
		public string RestaurantName { get; set; }
		public string Content { get; set; }
		public string Address { get; set; }
		public Country Country { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }
		public List<RestaurantImage> RestaurantImages { get; set; }
		public List<RestaurantComment> RestaurantComments { get; set; }
	}

	public class RestaurantImage
	{
		[Key]
		public int ImageId { get; set; }
		public string ImageURL { get; set; }
		public Restaurant Restaurant { get; set; }
		[ForeignKey("Restaurant")]
		public int RestaurantId { get; set; }

	}

	public class RestaurantComment
	{
		public int CommentId { get; set; }
		public string Content { get; set; }
		public User User { get; set; }
		[ForeignKey("User")]
		public int UserId { get; set; }
		public Restaurant Restaurant { get; set; }
		[ForeignKey("Restaurant")]
		public int RestaurantId { get; set; }
	}
}
}