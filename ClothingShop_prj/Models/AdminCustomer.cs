using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class AdminCustomer
    {
        public int AdminID { get; set; }
        public int CustomerID { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public DateTime ActionTime { get; set; } = DateTime.Now;
        //
        public virtual Customer Customers { get; set; }
        public virtual Admin Admins { get; set; }
    }
}