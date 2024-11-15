using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using K22CNT3_lehoanglong_2210900037.Models;
using static System.Collections.Specialized.BitVector32;

namespace K22CNT3_lehoanglong_2210900037.Controllers
{
    public class UsersController : Controller
    {
        private Entities db = new Entities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());

        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,taikhoan,matkhau,email,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,taikhoan,matkhau,email,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //login 
        public ActionResult Login()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            // Kiểm tra xem thông tin tài khoản và mật khẩu có đúng không
            var check = db.Users.FirstOrDefault(x => x.taikhoan.Equals(user.taikhoan) && x.matkhau.Equals(user.matkhau));
            if (check != null)
            {
                // Nếu thông tin đăng nhập hợp lệ, lưu thông tin vào Session và chuyển hướng người dùng
                Session["User"] = check;
                Session["RoleId"] = check.RoleId;
                if(check.RoleId == 1)
                {
                    ViewBag.Layout = "~/View/Shared/_Layout.cshtml";
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ViewBag.Layout = "~/Views/Shared/Layout2.cshtml";
                    return RedirectToAction("Index", "Customer");
                }
            }

            // Nếu thông tin đăng nhập không hợp lệ, trả về view với user để hiển thị thông báo lỗi
            ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
            return View(user);
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "user_id,taikhoan,matkhau,email,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tài khoản đã tồn tại chưa
                var existingUser = db.Users.FirstOrDefault(x => x.taikhoan == user.taikhoan);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Tài khoản này đã tồn tại.");
                    return View(user);
                }

                // Thêm người dùng mới vào cơ sở dữ liệu
                db.Users.Add(user);
                db.SaveChanges();


                TempData["Success"] = "Đăng ký thành công!";

                return RedirectToAction("Login", "Users"); // Chuyển hướng sau khi đăng ký thành công
            }

            return View(user);
        }



        // Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear(); // Xóa toàn bộ Session
            return RedirectToAction("Login", "Users");
        }
    }
}
