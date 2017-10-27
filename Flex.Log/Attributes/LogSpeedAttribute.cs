using Flex.Log.Data;
using Flex.Log.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Flex.Log.Attributes
{
    public  class LogSpeedAttribute : ActionFilterAttribute, IExceptionFilter
    {
     
        public string FlexKey;
        public static string methodName;
        public static string controllerName;
        public static DateTime requestStartDate;
        public static DateTime requestEndDate;
        public static double requestPeriod;
        
        public LogSpeedAttribute()
        {
            FlexKey = ConfigurationManager.AppSettings["FlexKey"];
            
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //CheckIfFlexKeyExist();
            methodName = filterContext.RouteData.Values["action"].ToString();
            controllerName = filterContext.RouteData.Values["controller"].ToString();
            requestStartDate = DateTime.Now;
           
        }

        public override void OnResultExecuted (ResultExecutedContext filterContext)
        {
            requestEndDate = DateTime.Now;
            TimeSpan span = requestStartDate - requestEndDate;

            requestPeriod = Math.Abs((requestStartDate - requestEndDate).TotalMilliseconds);
            DataAccess.SendLogDataToAPI(controllerName,methodName,requestStartDate,requestEndDate,requestPeriod);
            
        }

        public void OnException(ExceptionContext filterContext)
        {
            var mt = filterContext.Exception.StackTrace;
        }

        /// <summary>
        /// Checks if Flex key exist in Web.config
        /// else throws exception
        /// </summary>
        public void CheckIfFlexKeyExist()
        {
            if (FlexKey == null)
            {
                throw new Exception("Missing FlexKey in Web.Config");
            }
        }
    }
}
