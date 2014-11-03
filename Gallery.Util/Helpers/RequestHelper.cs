using System.Collections.Generic;
using System.Linq;

namespace Gallery.Util.Helpers
{
    public static class RequestHelper
    {
        public static string GenerateRequestUrl(string apiUrl, Dictionary<string, object> parameters)
        {
            var requestUrl = apiUrl + "?";
            return parameters.Aggregate(requestUrl, (current, parameter) => current + (parameter.Key + "=" + parameter.Value + "&"));

        }
    }
}
