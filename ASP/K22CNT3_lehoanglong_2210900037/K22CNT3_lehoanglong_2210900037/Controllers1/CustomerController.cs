using K22CNT3_lehoanglong_2210900037.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT3_lehoanglong_2210900037.Controllers1
{
    public class CustomerController : Controller
    {
        private Entities db = new Entities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Xin chào bạn, mời bạn đăng nhập để tiếp tục";

            return View();
        }

        public ActionResult Event()
        {
            return View(db.Sukiens.ToList());
        }
    }
}