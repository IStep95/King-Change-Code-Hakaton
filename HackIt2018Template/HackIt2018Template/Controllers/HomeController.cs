using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HackIt2018Template.Models;
using Models.Domain;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HackIt2018Template.ViewModels;

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

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]TeamRegisterViewModel teamData)
        {
            HttpResponseMessage response = await _repo.Register(teamData.Teamname, teamData.Password, teamData.Members);

            if (response.IsSuccessStatusCode)
            {
                JObject hackResult = JObject.Parse(await response.Content.ReadAsStringAsync());
                string hackNextStep = hackResult.GetValue("Result").ToString();
                return Ok("Tim je registriran");
            }
            else
            {
                JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                return BadRequest(responseObject.GetValue("Errors"));
            }
        }
    }
}
