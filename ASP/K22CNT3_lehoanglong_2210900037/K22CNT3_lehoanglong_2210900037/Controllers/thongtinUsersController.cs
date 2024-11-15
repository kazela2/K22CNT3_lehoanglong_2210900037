using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_lehoanglong_2210900037.Models;

namespace K22CNT3_lehoanglong_2210900037.Controllers
{
    public class thongtinUsersController : Controller
    {
        private Entities db = new Entities();

        // GET: thongtinUsers
        public ActionResult Index()
        {
            var thongtinUsers = db.thongtinUsers.Include(t => t.User);
            return View(thongtinUsers.ToList());
        }

        // GET: thongtinUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinUser thongtinUser = db.thongtinUsers.Find(id);
            if (thongtinUser == null)
            {
                return HttpNotFound();
            }
            return View(thongtinUser);
        }

        // GET: thongtinUsers/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan");
            return View();
        }

        // POST: thongtinUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tt_id,user_id,fullname,avatar,tieusu")] thongtinUser thongtinUser)
        {
            if (ModelState.IsValid)
            {
                db.thongtinUsers.Add(thongtinUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", thongtinUser.user_id);
            return View(thongtinUser);
        }

        // GET: thongtinUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinUser thongtinUser = db.thongtinUsers.Find(id);
            if (thongtinUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", thongtinUser.user_id);
            return View(thongtinUser);
        }

        // POST: thongtinUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tt_id,user_id,fullname,avatar,tieusu")] thongtinUser thongtinUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongtinUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", thongtinUser.user_id);
            return View(thongtinUser);
        }

        // GET: thongtinUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinUser thongtinUser = db.thongtinUsers.Find(id);
            if (thongtinUser == null)
            {
                return HttpNotFound();
            }
            return View(thongtinUser);
        }

        // POST: thongtinUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thongtinUser thongtinUser = db.thongtinUsers.Find(id);
            db.thongtinUsers.Remove(thongtinUser);
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
    }
}
