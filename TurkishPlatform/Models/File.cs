using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class File
    {
        public int FileID { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteUrl { get; set; }
        public string deleteType { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
    }
    public class FileList
    {
        public List<File> files = new List<File>();
    }
}