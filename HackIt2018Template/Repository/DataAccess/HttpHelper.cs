using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public class HttpHelper
    {
        private HttpClient _client;

        public HttpHelper()
        {
            _client = new HttpClient();
        }

        public void setBaseUrl(string url)
        {
            _client.BaseAddress = new Uri(url);
        }

        public async Task<HttpResponseMessage> GetResponse(string resourceUrl)
        {
            var response = await _client.GetAsync(resourceUrl);
            return response;
        }
    }
}
