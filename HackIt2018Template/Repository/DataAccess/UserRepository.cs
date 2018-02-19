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
            _context.setBaseUrl("http://sportfinderapi.azurewebsites.net");
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            HttpResponseMessage data = await _context.GetResponse("/api/Events/FindEvents?sportId=1&date=26/01/2018&cityName=Zagreb&freePlayers=0");
            IEnumerable <Event> events = new List<Event>();

            if (data.IsSuccessStatusCode)
            {
                if (data.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JArray jArray = JArray.Parse(await data.Content.ReadAsStringAsync());
                    events = jArray.ToObject<List<Event>>();
                }
            }
            return events;
        }

        public async Task<Event> GetEvent(int id)
        {
            HttpResponseMessage data = await _context.GetResponse("/api/Events/GetEvent/1");
            Event event1 = new Event();

            if (data.IsSuccessStatusCode)
            {
                if (data.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JObject jObject = JObject.Parse(await data.Content.ReadAsStringAsync());
                    event1 = jObject.ToObject<Event>();
                }
            }
            return event1;
        }
    }
}
