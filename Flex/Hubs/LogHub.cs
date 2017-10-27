using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flex.Hubs
{
    public class LogHub : Hub
    {
        public void Send(string controllerName, string methodName, string requestStartDate, string requestEndDate, double requestPeriod)
        {
            Clients.All.AddRequestLogToPage(controllerName, methodName, requestStartDate, requestEndDate, requestPeriod);
        }
    }
}