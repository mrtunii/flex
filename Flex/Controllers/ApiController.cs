using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flex.Controllers
{
    public class ApiController : Controller
    {
        [Route("api/sendlog")]
        // GET: api/sendlog
        public JsonResult Index()
        {

            return Json("");
        }
    }
}