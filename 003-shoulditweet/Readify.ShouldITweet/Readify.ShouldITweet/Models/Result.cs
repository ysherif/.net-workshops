using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readify.ShouldITweet.Models
{
    public class Result
    {
        public string Message { get; set; }
       
        public Result(string message)
        {
            Message = message;
        }

        public Result()
        {
            Message = string.Empty;

        }
    }
}