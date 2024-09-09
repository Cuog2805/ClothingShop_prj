using ClothingShop_prj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop_prj.Controllers
{
    public class ShopController : Controller
    {
        private ClothingShopDbContext db = new ClothingShopDbContext();
        public class Link
        {
            public string Section { get; set; } = "Products";
            public string Category { get; set; }
            public string Type { get; set; }
        }
        public class Filter
        {
            public List<Size> Sizes { get; set; }
            public List<Color> Colors { get; set; }
            public UserObject userObj { get; set; }
        }
        public ActionResult Index(string sortOrder, string color, string size, string section = "Products", string category = null, string type = null)
        {
            Link link = new Link() { Section = section, Category = category, Type = type};
            return View(link);
        }
        public PartialViewResult Slider(Link link)
        {
            Filter filter = new Filter() 
            { 
                Sizes = db.Sizes.ToList(),  
                Colors = db.Colors.ToList(),
                userObj = db.UserObjects.FirstOrDefault(m => m.Name == link.Section)
            };
            return PartialView("Slider", filter);
        }
        public PartialViewResult Products()
        {
            List<Product> productList = db.Products.ToList();
            return PartialView("Products", productList);
        }
        public PartialViewResult Men(Link link)
        {
            List<Product> menProduct = db.Products
                .Where(p => p.CategoryItems.Any(ci => ci.Category.UserObject.Name == link.Section)).ToList();
            if (!string.IsNullOrEmpty(link.Type))
            {
                menProduct = db.Products
                    .Where(p => p.Types
                    .Any(t => t.Name == link.Type && t.UserObject.Name == link.Section))
                    .ToList();
            } 
            if(!string.IsNullOrEmpty(link.Category))
            {
                menProduct = db.Products
                    .Where(p => p.CategoryItems
                    .Any(ci => ci.Name == link.Category && ci.Category.UserObject.Name == link.Section))
                    .ToList();
            }
            return PartialView("Men", menProduct);
        }
        public PartialViewResult Women(Link link)
        {
            List<Product> womenProduct = db.Products
                .Where(p => p.CategoryItems.Any(ci => ci.Category.UserObject.Name == link.Section)).ToList();
            if (!string.IsNullOrEmpty(link.Type))
            {
                womenProduct = db.Products
                    .Where(p => p.Types
                    .Any(t => t.Name == link.Type && t.UserObject.Name == link.Section))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(link.Category))
            {
                womenProduct = db.Products
                    .Where(p => p.CategoryItems
                    .Any(ci => ci.Name == link.Category && ci.Category.UserObject.Name == link.Section))
                    .ToList();
            }
            return PartialView("Women", womenProduct);
        }
        public PartialViewResult Children(Link link)
        {
            List<Product> childrenProduct = db.Products
                .Where(p => p.CategoryItems.Any(ci => ci.Category.UserObject.Name == link.Section)).ToList();
            if (!string.IsNullOrEmpty(link.Type))
            {
                childrenProduct = db.Products
                    .Where(p => p.Types
                    .Any(t => t.Name == link.Type && t.UserObject.Name == link.Section))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(link.Category))
            {
                childrenProduct = db.Products
                    .Where(p => p.CategoryItems
                    .Any(ci => ci.Name == link.Category && ci.Category.UserObject.Name == link.Section))
                    .ToList();
            }
            return PartialView("Children", childrenProduct);
        }
        public PartialViewResult Infant(Link link)
        {
            List<Product> infantProduct = db.Products
                .Where(p => p.CategoryItems.Any(ci => ci.Category.UserObject.Name == link.Section)).ToList();
            if (!string.IsNullOrEmpty(link.Type))
            {
                infantProduct = db.Products
                    .Where(p => p.Types
                    .Any(t => t.Name == link.Type && t.UserObject.Name == link.Section))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(link.Category))
            {
                infantProduct = db.Products
                    .Where(p => p.CategoryItems
                    .Any(ci => ci.Name == link.Category && ci.Category.UserObject.Name == link.Section))
                    .ToList();
            }
            return PartialView("Infant", infantProduct);
        }
        public ActionResult Detail()
        {
            return View();
        }
    }
}