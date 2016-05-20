using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bitaka.Models
{
    public class Products
    {  
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        //public List<string> category = new List<string>() { "Fashion", "Electronics", "Vehicles", "Animals", "Babies", "Home" };
        public string Category { get; set; }
        public bool Used { get; set; }

        private DateTime created = DateTime.Now;
        public DateTime Created { get { return created; } set { created = value; } }
        public  string Image { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } 
    }
}