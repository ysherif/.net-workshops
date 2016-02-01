using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Readify.ShouldITweetClient.DAL;

namespace Readify.ShouldITweetClient.Controllers
{
    public class TweetController : ApiController
    {
        public IHttpActionResult Post(string tweet)
        {
            var responseMessage =  CheckTweet(tweet);
            return Ok(responseMessage);
        }

        private string CheckTweet(string tweet)
        {
            WordContext db = new WordContext(); 

            var notAllowedWords = db.Words.ToList();

            if (tweet.Length > 140)
            {
                return "The tweet must be less than or equal 140 characters.";
            }

            if (string.IsNullOrEmpty(tweet))
            {
                return "Please type in a tweet and try again.";
            }

            foreach (var word in notAllowedWords)
            {
                if (tweet.ToLower().Split(' ').FirstOrDefault(o => o.Trim('.', ',', '/', '-') == word.WordText.ToLower()) != null)
                {
                    return $"The tweet contains word '{word.WordText}' which is not appropriate.";
                }
            }
            return "The tweet doesn't contain any inappropriate words. You can post it!";
        }
    }
}
