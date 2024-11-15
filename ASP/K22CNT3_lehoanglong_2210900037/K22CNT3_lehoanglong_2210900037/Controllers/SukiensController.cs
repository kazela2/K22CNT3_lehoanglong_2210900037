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
    public class SukiensController : Controller
    {
        private Entities db = new Entities();

        // GET: Sukiens
        public ActionResult Index()
        {
            return View(db.Sukiens.ToList());
        }

        // GET: Sukiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sukien sukien = db.Sukiens.Find(id);
            if (sukien == null)
            {
                return HttpNotFound();
            }
            return View(sukien);
        }

        // GET: Sukiens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sukiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ev_id,tieude,noidung")] Sukien sukien)
        {
            if (ModelState.IsValid)
            {
                db.Sukiens.Add(sukien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sukien);
        }

        // GET: Sukiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sukien sukien = db.Sukiens.Find(id);
            if (sukien == null)
            {
                return HttpNotFound();
            }
            return View(sukien);
        }

        // POST: Sukiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ev_id,tieude,noidung")] Sukien sukien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sukien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sukien);
        }

        // GET: Sukiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sukien sukien = db.Sukiens.Find(id);
            if (sukien == null)
            {
                return HttpNotFound();
            }
            return View(sukien);
        }

        // POST: Sukiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sukien sukien = db.Sukiens.Find(id);
            db.Sukiens.Remove(sukien);
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
