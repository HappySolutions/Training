using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SweetsDokkana.Models
{
    public class Customer 
    {

        public string id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
