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
    public class thamgiasController : Controller
    {
        private Entities db = new Entities();

        // GET: thamgias
        public ActionResult Index()
        {
            var thamgias = db.thamgias.Include(t => t.Sukien).Include(t => t.User);
            return View(thamgias.ToList());
        }

        // GET: thamgias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thamgia thamgia = db.thamgias.Find(id);
            if (thamgia == null)
            {
                return HttpNotFound();
            }
            return View(thamgia);
        }

        // GET: thamgias/Create
        public ActionResult Create()
        {
            ViewBag.ev_id = new SelectList(db.Sukiens, "ev_id", "tieude");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan");
            return View();
        }

        // POST: thamgias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tg_id,user_id,ev_id,ngaythamgia")] thamgia thamgia)
        {
            if (ModelState.IsValid)
            {
                db.thamgias.Add(thamgia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ev_id = new SelectList(db.Sukiens, "ev_id", "tieude", thamgia.ev_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", thamgia.user_id);
            return View(thamgia);
        }

        // GET: thamgias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thamgia thamgia = db.thamgias.Find(id);
            if (thamgia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ev_id = new SelectList(db.Sukiens, "ev_id", "tieude", thamgia.ev_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", thamgia.user_id);
            return View(thamgia);
        }

        // POST: thamgias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tg_id,user_id,ev_id,ngaythamgia")] thamgia thamgia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thamgia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ev_id = new SelectList(db.Sukiens, "ev_id", "tieude", thamgia.ev_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", thamgia.user_id);
            return View(thamgia);
        }

        // GET: thamgias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thamgia thamgia = db.thamgias.Find(id);
            if (thamgia == null)
            {
                return HttpNotFound();
            }
            return View(thamgia);
        }

        // POST: thamgias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thamgia thamgia = db.thamgias.Find(id);
            db.thamgias.Remove(thamgia);
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
