using Flex.Log.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Flex.Log.Attributes
{
    public  class LogSpeedAttribute : ActionFilterAttribute, IExceptionFilter
    {
     
        public string FlexKey;
        
        public LogSpeedAttribute()
        {
            FlexKey = ConfigurationManager.AppSettings["FlexKey"];
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //CheckIfFlexKeyExist();
            LogModel.MethodName = filterContext.RouteData.Values["action"].ToString();
            LogModel.ControllerName = filterContext.RouteData.Values["controller"].ToString();
            LogModel.RequestStartDate = DateTime.Now;
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogModel.RequestEndDate = DateTime.Now;
            LogModel.CalculateRequestPeriod();
            base.OnActionExecuted(filterContext);
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
