using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HackIt2018Template.Models;
using Models.Domain;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HackIt2018Template.ViewModels;
using Microsoft.AspNetCore.Http;
using System;

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
                return Ok("Tim je registriran");
            }
            else
            {
                JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                return BadRequest(responseObject.GetValue("Errors"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]TeamRegisterViewModel teamData)
        {
            HttpResponseMessage response = await _repo.Login(teamData.Teamname, teamData.Password);

            if (response.IsSuccessStatusCode)
            {
                JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                string responseString = responseObject.GetValue("Result").ToString();
                JObject team = JObject.Parse(responseString);
                string token = team.GetValue("AuthorizationToken").ToString();
                int id = Int32.Parse(team.GetValue("TeamId").ToString()) ;
                HttpContext.Session.SetInt32("TeamId", id);
                HttpContext.Session.SetString("AuthToken", token);
                return Ok();
            }
            else
            {
                JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                return BadRequest(responseObject.GetValue("Errors"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> TeamDetails()
        {
            int? teamId = HttpContext.Session.GetInt32("TeamId");
            if (teamId == null) return BadRequest();
            string token = HttpContext.Session.GetString("AuthToken");
            HttpResponseMessage response = await _repo.TeamDetails(teamId.Value, token);
            JObject responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
            string responseString = responseObject.GetValue("Result").ToString();
            return Ok(responseString);
        }
    }
}
