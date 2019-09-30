using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.IntegrationTests
{
    public static class Helper
    {
        public static Task<HttpResponseMessage> PatchJsonAsync(this HttpClient client, string requestUri, Type type, object value)
        {
            return client.PatchAsync(requestUri, new ObjectContent(type, value, new JsonMediaTypeFormatter(), "application/json"));
        }
    }
}
