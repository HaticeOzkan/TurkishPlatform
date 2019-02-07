using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class AdminProfil
    {
        [Key]
        public int InfoID { get; set; }
        [Required]
        [MaxLength(100)]
        public string MailAdress { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}