using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        //navigation propertys
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Address> AddressList { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual History History { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual Wishlist Wishlist { get; set; }
        public virtual ICollection<AdminCustomer> AdminCustomers { get; set; }
    }
}