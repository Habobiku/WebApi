using System;
using System.Collections.Generic;

namespace Bot.Dota2
{
    public class teams
    {
        public string name { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public List<players> players { get; set; }
    }
    public class players
    {
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string image_url { get; set; }
        public int id { get; set; }
    }

}

