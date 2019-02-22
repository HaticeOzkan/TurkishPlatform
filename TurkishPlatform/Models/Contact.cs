using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        public string Content { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime ContactTime { get; set; }
        public Contact()
        {
            ContactTime = DateTime.Now;
        }
    }
}