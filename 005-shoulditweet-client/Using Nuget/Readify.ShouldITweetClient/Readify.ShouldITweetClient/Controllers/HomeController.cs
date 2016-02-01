using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Readify.ShouldITweetClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageWords()
        {
            return View();
        }

        public ActionResult CreateWord()
        {
            return View();
        }

    }
}