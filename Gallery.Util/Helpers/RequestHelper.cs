using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;

namespace Gallery.Util.Helpers
{
    public static class RequestHelper
    {
        public static string GenerateRequestUrl(string urlAPI, Dictionary<string, string> parameters)
        {
            var requestUrl = urlAPI + "?";
            return parameters.Aggregate(requestUrl, (current, parameter) => current + (parameter.Key + "=" + parameter.Value + "&"));

        }

        public static HttpResponseMessage SendRequest(string urlAPI, Dictionary<string, string> parameters,
            string httpMethod, bool allowWriteStreamBuffering)
        {
            HttpResponseMessage result=null;
            using (var client = new HttpClient())
            {
                switch (httpMethod.ToLower())
                {
                    case "get":
                        result = client.GetAsync(GenerateRequestUrl(urlAPI, parameters)).Result;
                        break;
                    case "post":
                        break;
                    case "put":
                      //  result = client.PutAsync(urlAPI, new HttpContent().);
                        break;
                    case "delete": break;
                }
            }
            return result;
        }
    }
}
