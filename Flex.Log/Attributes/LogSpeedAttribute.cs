using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Flex.Log.Attributes
{
    public class LogSpeedAttribute : ActionFilterAttribute
    {
        public string controllerName;
        public string methodName;
        public DateTime requestStartDate;
        public DateTime requestEndDate;
        /// <summary>
        /// Key generated in Flex system
        /// </summary>
        public string FlexKey;
        /// <summary>
        ///    How much time did it take to  complete request basically it's subtraction of requestStartDate and requestEndDate (in Milliseconds)
        /// </summary>
        public long requestPeriod;
        public LogSpeedAttribute()
        {
            FlexKey = ConfigurationManager.AppSettings["FlexKey"];
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CheckIfFlexKeyExist();
            controllerName = filterContext.RouteData.Values["controller"].ToString();
            methodName = filterContext.RouteData.Values["action"].ToString();
            requestStartDate = DateTime.Now;
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            requestEndDate = DateTime.Now;
            requestPeriod = requestStartDate.Millisecond - requestEndDate.Millisecond;
            base.OnActionExecuted(filterContext);
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
