using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackIt2018Template.ViewModels
{
    public class TeamRegisterViewModel
    {
        public string Teamname { get; set; }
        public string Password { get; set; }
        public List<User> Members { get; set; }
    }
}
