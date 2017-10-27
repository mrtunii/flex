using Flex.Log.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace Flex.Log.Data
{
    class DataAccess
    {
        
        public static void SendLogDataToAPI(string controllerName, string methodName, DateTime requestStartDate, DateTime requestEndDate, double requestPeriod )
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("controllerName", controllerName);
            data.Add("methodName", methodName);
            data.Add("requestStartDate", requestStartDate.ToString());
            data.Add("requestEndDate", requestEndDate.ToString());
            data.Add("requestPeriod", requestPeriod.ToString());
            string json = dictionaryToPostString(data);
            HttpWebRequest request = null;
            Uri uri = new Uri("http://localhost:24080/api/log");
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.SendChunked = true;

            request.KeepAlive = true;
            var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(json);
            streamWriter.Close();

            var response = request.GetResponse();
            
        }


        public static string dictionaryToPostString(Dictionary<string, string> postVariables)
        {
            string postString = "";
            foreach (KeyValuePair<string, string> pair in postVariables)
            {
                postString += HttpUtility.UrlEncode(pair.Key) + "=" +
                    HttpUtility.UrlEncode(pair.Value) + "&";
            }

            return postString;
        }

    }
}
