using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flex.Log.Attributes;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [LogSpeed]
        public ActionResult Index()
        {
            return View();
        }
    }
}