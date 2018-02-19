using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HackIt2018Template.Models;
using Models.Domain;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HackIt2018Template.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _repo;

        public HomeController(IUserRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
             
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<JArray> GetAllEvents()
        {
            IEnumerable<Event> events = await _repo.GetAllEvents();

            //naprevi neke akcije s eventima

            //serializiraj natrag u json
            return JArray.FromObject(events);
        }
    }
}
