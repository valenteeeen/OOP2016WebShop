﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Bitaka.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        [Display(Name="Full Name")]
        public string FullName { get; set; }
     
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ShoppingCart ShopingCart { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public System.Collections.IEnumerable IdentityUsers { get; set; }
    }
}