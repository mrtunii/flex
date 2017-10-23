using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Flex.Log.Data
{
    class DataAccess
    {
        public async Task SendData()
        {
            var str = SendPostRequest();

            Debug.WriteLine("postData:" + str);
        }

        public async Task SendPostRequest()
        {
            using (var client = new HttpClient())
            {
                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("variable", "hello"));
                var content = new FormUrlEncodedContent(values);

                  await client.PostAsync("http://localhost:24080/", content);
                Debug.WriteLine("async");
                
            }
        }
    }
}
