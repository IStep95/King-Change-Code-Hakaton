using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<HttpResponseMessage> GetResponseAuth(string resourceUrl, string token)
        {
            _client.DefaultRequestHeaders.Add("X-Authorization", token);
            var response = await _client.GetAsync(resourceUrl);
            return response;
        }

        public async Task<HttpResponseMessage> PostString(string resourceUrl, JObject jsonObject)
        {
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(resourceUrl, content);
            return response;
        }
    }
}
