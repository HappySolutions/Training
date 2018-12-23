using System;
using System.Collections.Generic;
using System.Text;

namespace SweetsDokkana.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string brand { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string image_link { get; set; }
    }
}
