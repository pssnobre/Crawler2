﻿using CrawlerBusinessServices.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crawler2.Models
{
    public class CrawlerViewModel
    {
        public CrawlerViewModel()
        {
            Images = new List<string>();
        }

        [Required(ErrorMessage = "Url is required.")]
        [RegularExpression(@"^(https?|ftp)://[^\s/$.?#].[^\s]*$", ErrorMessage = "Please type a valid url.")]
        public string Url { get; set; }
        public IEnumerable<string> Images { get; set; }

        //public Dictionary<string, int> WordCount { get; set; }

        public IEnumerable<Word> Words { get; set; }
    }
}