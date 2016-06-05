using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bitaka.Models
{
    public class ShoppingCart
    {
        [Key, ForeignKey("ApplicationUser")]
        public string id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Products> Products { get; set; }




        public int Count { get; set; }

        public int ProductId { get; set; }
    }
}