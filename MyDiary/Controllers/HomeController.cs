using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDiary.Controllers
{
    public class HomeController : Controller
    {
        // GET: Stories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutMe()
        {
            return View();
        }

        public ActionResult NewStories()
        {
            return View();
        }

        public ActionResult Caroucel()
        {
            return View();
        }
    }
}