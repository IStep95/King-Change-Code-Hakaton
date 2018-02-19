using Models.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public class UserRepository : IUserRepository
    {

        private HttpHelper _context;

        public UserRepository()
        {
            _context = new HttpHelper();
            _context.setBaseUrl("http://52.233.158.172/change/api/hr/");
        }

        public async Task<HttpResponseMessage> Login(string teamName, string password)
        {
            JObject jsonObject = new JObject();
            jsonObject.Add("Teamname", teamName);
            jsonObject.Add("Password", password);

            return await _context.PostString("account/login", jsonObject);
        }

        public async Task<HttpResponseMessage> Register(string teamName, string password, List<User> users)
        {
            JObject jsonObject = new JObject();
            jsonObject.Add("Teamname", teamName);
            jsonObject.Add("Password", password);
            jsonObject.Add("Members", JArray.FromObject(users));
            
            return await _context.PostString("account/register", jsonObject);
        }

        public async Task<HttpResponseMessage> TeamDetails(int id, string token)
        {
            return await _context.GetResponseAuth("team/details/" + id, token);
        }
    }
}
