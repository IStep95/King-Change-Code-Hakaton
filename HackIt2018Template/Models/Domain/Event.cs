using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Domain
{
   public class Event
    {
        public string CityName { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public string SportName { get; set; }
    }
}
