using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serilog;

namespace Readify.ShouldITweet2.Controllers
{
    using Models;
    using DAL;

    public class HomeController : Controller
    {
        private WordContext db = new WordContext();

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
            var notAllowedWords = db.Words.ToList();

            if (tweet.Length > 140)
            {
                Log.Error("Tweet was less than 140 characters.");
                return new Result("The tweet must be less than or equal 140 characters.");
            }

            if (string.IsNullOrEmpty(tweet))
            {
                Log.Error("An empty tweet has been submitted.");
                return new Result("Please type in a tweet and try again.");
            }

            foreach (var word in notAllowedWords)
            {
                if (tweet.ToLower().Split(' ').FirstOrDefault(o => o.Trim('.',',','/','-') == word.WordText.ToLower()) != null)
                {
                    Log.Error($"A tweet contains word '{word.WordText}' has been submitted");
                    return new Result($"The tweet contains word '{word.WordText}' which is not appropriate.");
                }
            }

            Log.Information("The tweet doesn't contain any inappropriate words.");
            return new Result("The tweet doesn't contain any inappropriate words. You can post it!");
        }
    }
}