using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class Country
    {
        [Key]
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public List<User> Users { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public List<Tourism> Tourisms { get; set; }
        public List<Topic> Topics { get; set; } 
        public List<Advice> Advices { get; set; }

    }
}