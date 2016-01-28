using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Readify.ShouldITweet.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(string txtTweet)
        {
            var result = CheckTweet(txtTweet);
            return View("Result", result);
        }
   
        private Result CheckTweet(string tweet)
        {
            List<string> notAllowedWords = new List<string>() {"Trump","Selfie"};

            if (tweet.Length > 140)
                return new Result("Tweet must be less than or equal 140 characters.");

            foreach (var word in notAllowedWords)
            {
                if(tweet.ToLower().Split(' ').FirstOrDefault(o=>o == word.ToLower()) != null)
                {
                    return new Result($"Tweet contains word '{word}' which is not appropriate.");
                }
            }

            return new Result("Tweet doesn't contain any inappropriate words. You can post it!");   
        }
    }
}