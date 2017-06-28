using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Text;
using System.Net;
using System.IO;

namespace NDAGenLib.DataAccess
{
    public class RESTAccess
    {
        public string ConnectionString { get; set; }

        public RESTAccess()
        {
        }
        public RESTAccess(string baseConnectionString)
        {
            ConnectionString = baseConnectionString;
        }
        public async Task<string> Request(string method, string requestType, Dictionary<string, string> param, string AuthToken = "", string postData = null, string contentType = "application/json")
        {
            string url = BuildRequestString(method, param);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContinueTimeout = 3000;
            request.ContentType = contentType;
            request.Method = requestType;
            if (AuthToken != "")
                request.Headers["Authorization"] = "Bearer " + AuthToken;
            if (requestType != "GET" && postData != null)
            {
                using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
                {
                    await streamWriter.WriteAsync(postData.ToString());
                    await streamWriter.FlushAsync();
                }
            }
            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    try
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        private string BuildRequestString(string methodName, Dictionary<string, string> param)
        {
            StringBuilder request = new StringBuilder();
            request.Append(ConnectionString)
                .Append("/")
                .Append(methodName)
                .Append("?");

            foreach (var item in param)
            {

                request.Append("&")
                    .Append(item.Key)
                    .Append("=")
                    .Append(item.Value);

            }
            request.Replace("?&", "?");
            if (param.Count == 0)
                request.Replace("?", "");
            return request.ToString();
        }
    }
}

