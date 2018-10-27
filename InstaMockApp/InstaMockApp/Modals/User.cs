using System;
using System.Collections.Generic;
using System.Text;

namespace InstaMockApp.Modals
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl
        {
            get { return  $"http://lorempixel.com/100/100/people/{Id}"; } 
        }
    }
}
