using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Readify.ShouldITweet2.Models
{
    public class Word
    {
        public int WordID { get; set; }

        [Required]
        [DisplayName("Word")]
        public string WordText { get; set; }
        
    }
}