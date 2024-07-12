using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class AdminProduct
    {
        public int AdminID { get; set; }
        public int ProductID { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public DateTime ActionTime { get; set; } = DateTime.Now;
        //
        public virtual Product Products { get; set;}
        public virtual Admin Admins { get; set;}
    }
}