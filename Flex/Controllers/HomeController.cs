using Flex.Log.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flex.Controllers
{
    public class HomeController : Controller
    {
        [LogSpeed]
        // GET: Home
        public ActionResult Index()
        {
            throw new Exception("hello");
            return View();
        }
    }
}