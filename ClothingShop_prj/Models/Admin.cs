using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        [Required]
        public string AdminName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        //
        public virtual ICollection<AdminProduct> AdminProducts { get; set; }
        public virtual ICollection<AdminCustomer> AdminCustomers { get; set; }
    }
}