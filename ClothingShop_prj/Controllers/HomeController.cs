using ClothingShop_prj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop_prj.Controllers
{
    public class HomeController : Controller
    {
        private ClothingShopDbContext db = new ClothingShopDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult NavigationBar()
        {
            List<UserObject> userObjectList = db.UserObjects.Include("Categories").ToList();
            return PartialView("NavigationBar", userObjectList);
        }
    }
}