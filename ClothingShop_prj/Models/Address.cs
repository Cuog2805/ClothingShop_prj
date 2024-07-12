using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        [Required]
        public string Content { get; set; }
        public virtual Customer Customer { get; set; }
    }
}