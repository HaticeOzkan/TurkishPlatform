﻿using System;
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
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Remaining { get; set; }
		public Country Country { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }

        public Activity()
        {
            Remaining = Date - DateTime.Now;
        }
    }
}