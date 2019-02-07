using System;
using System.Collections.Generic;
using System.Text;

namespace SweetsDokkana.Models
{
    public class Product
    {
        public string id { get; set; }
        public string pro_name { get; set; }
        public string pro_price { get; set; }
        public string pro_description { get; set; }
        public string pro_img { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class RootObject
    {
        public int count { get; set; }
        public List<Product> rows { get; set; }
    }
}
