using System;
using System.Collections.Generic;
using System.Text;

namespace InstaMockApp.Modals
{
    class Activity
    {
        private string image = "http://lorempixel.com/100/100/people/{UserId}";

        public int UserId { get; set; }
        public string Description { get; set; }
        public string ImageUrl{ get { return $"http://lorempixel.com/100/100/people/{UserId}"; } }
    }
}
