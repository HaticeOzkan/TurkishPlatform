using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class RestaurantViewModel
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
		public string CoverImageURL { get; set; }

	}
}