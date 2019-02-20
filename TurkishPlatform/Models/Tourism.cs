using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class Tourism
    {
		[Key]
		public int LocationId { get; set; }
		[Required]
		[MaxLength(200)]
		public string LocationName { get; set; }
		[MaxLength(1000)]
		public string Content { get; set; }
		[Required]
		[MaxLength(500)]
		public string Address { get; set; }
		public Country Country { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }
		public virtual List<LocationImage> LocationImages { get; set; }
		public virtual List<LocationComment> locationComments { get; set; }
    }
	
	public class LocationImage
	{
		[Key]
		public int ImageId { get; set; }
		[Required]
		[MaxLength(1000)]
		public string ImageURL { get; set; }
		public Tourism Location { get; set; }
		[ForeignKey("Location")]
		public int LocationId { get; set; }
	}

	public class LocationComment
	{
        [Key]
		public int CommentId { get; set; }
		public string Content { get; set; }
		public virtual User User { get; set; }
		[ForeignKey("User")]
		public int UserId { get; set; }
		public virtual Tourism Location { get; set; }
		[ForeignKey("Location")]
		public int LocationId { get; set; }
        public bool Permission { get; set; }
        public LocationComment()
        {
            Permission = false;
        }
	}
}