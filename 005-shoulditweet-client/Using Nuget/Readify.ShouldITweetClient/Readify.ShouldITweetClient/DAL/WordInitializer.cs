using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readify.ShouldITweet2.DAL
{
    using Models;
    public class WordInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WordContext>
    {
        protected override void Seed(WordContext context)
        {
            var words = new List<Word>
            {
            new Word{WordText = "Trump" },
            new Word{WordText = "Selfie"},
            };

            words.ForEach(w => context.Words.Add(w));
            context.SaveChanges();
        }
    }
    
}