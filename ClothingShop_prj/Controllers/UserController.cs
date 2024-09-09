using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop_prj.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Profile(string section="Userinfo")
        {
            return View((object)section);
        }
        public PartialViewResult Slider(string section = "Userinfo")
        {
            return PartialView("Slider", (object)section);
        }
        public PartialViewResult Userinfo()
        {
            return PartialView("Userinfo");
        }
        public PartialViewResult Discountcoupon()
        {
            return PartialView("Discountcoupon");
        }
        public PartialViewResult Historyproducts()
        {
            return PartialView("Historyproducts");
        }
        public PartialViewResult Historyorders()
        {
            return PartialView("Historyorders");
        }
        public PartialViewResult Editprofile()
        {
            return PartialView("Editprofile");
        }
        public PartialViewResult Addressbook()
        {
            return PartialView("Addressbook");
        }
        public PartialViewResult Changepassword()
        {
            return PartialView("Changepassword");
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}