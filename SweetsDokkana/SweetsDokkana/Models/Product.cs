using System;

namespace SweetsDokkana.Models
{
    public class Product
    {
        public string id { get; set; }
        public string Pro_Name { get; set; }
        public string Pro_Description { get; set; }
        public string Pro_Price { get; set; }
        public string Pro_IMG { get; set; }
        public int numberInStock { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

}

