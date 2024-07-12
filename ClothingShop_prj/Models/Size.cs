using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Size
    {
        public int SizeID { get; set; }
        [Required]
        public string Amplitude { get; set; }
        public virtual ICollection<Product> Products { get; set;}
    }
}