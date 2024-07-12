using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class CategoryItem
    {
        public int CategoryItemID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Category Category { get; set; }
    }
}