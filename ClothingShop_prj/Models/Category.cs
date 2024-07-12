using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<CategoryItem> CategorieItems { get; set; }
    }
}