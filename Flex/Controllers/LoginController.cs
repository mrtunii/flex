﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flex.Controllers
{
    public class LoginController : Controller
    {
        [Route("login")]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

      
    }
}