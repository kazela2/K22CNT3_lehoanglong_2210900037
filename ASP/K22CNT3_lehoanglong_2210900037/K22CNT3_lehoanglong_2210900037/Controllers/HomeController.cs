using K22CNT3_lehoanglong_2210900037.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT3_lehoanglong_2210900037.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                var user = Session["User"] as User;
                ViewBag.Fullname = user.email;
            }    
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Xin chào bạn, mời bạn đăng nhập để tiếp tục";

            return View();
        }
    }
}