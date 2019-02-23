using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkishPlatform.Models
{
    public class ScoreViewModel
    {
        public string NameSurname { get; set; }
        public double Score { get; set; }
        public string ImageURL { get; set; }
        public int UserID { get; set; }
        public int CountryNo { get; set; }

        public ScoreViewModel()
        {
            Score = 0;
        }
    }
}