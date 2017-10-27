using Flex.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flex.Controllers
{
    public class ApiController : Controller
    {
        [Route("api/log")]
        [HttpPost]
        // GET: api/sendlog
        public void Index(string controllerName, string methodName, DateTime requestStartDate, DateTime requestEndDate, double requestPeriod)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
            hubContext.Clients.All.AddRequestLogToPage(controllerName, methodName, requestStartDate, requestEndDate, requestPeriod);
        }

        
    }
}