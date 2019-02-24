using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
	public class Advice
	{
		[Key]
		public int AdviceId { get; set; }
		[Required]
		[MaxLength(200)]
		public string Title { get; set; }
		[Required]
		[Column(TypeName = "text")]
		public string Content { get; set; }
		public string ImageURL { get; set; }
		public DateTime Date { get; set; }
		public AdviceTopic AdviceTopic { get; set; }
        public int AdviceTopicID { get; set; }

		public Advice()
		{
			Date = DateTime.Today;
		}
	}

	public class AdviceTopic
	{
		[Key]
		public int CategoryId { get; set; }
		[Required]
		[MaxLength(200)]
		public string CategoryName { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public virtual List<Advice> Advices { get; set; }
	}
}