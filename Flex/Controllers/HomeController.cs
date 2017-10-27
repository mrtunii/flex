using Flex.Log.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            return View();
        }

        public ActionResult TestSignal()
        {
            return View();
        }
        
    }
}