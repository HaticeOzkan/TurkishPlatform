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
		public string Title { get; set; }
		public string Content { get; set; }
		public string ImageURL { get; set; }
		public DateTime Date { get; set; }
		[ForeignKey("CountryId")]
		public Country Country { get; set; }
		public int CountryId { get; set; }
		public List<AdviceTopic> AdviceTopics { get; set; }

		public Advice()
		{
			Date = DateTime.Today;
		}
	}

	public class AdviceTopic
	{
		[Key]
		public string CategoryId { get; set; }
		public string CategoryName { get; set; }
		public Advice Advice { get; set; }
		[ForeignKey("Advice")]
		public int AdviceId { get; set; }
	}
}