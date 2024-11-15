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
    public class danhgiasController : Controller
    {
        private Entities db = new Entities();

        // GET: danhgias
        public ActionResult Index()
        {
            var danhgias = db.danhgias.Include(d => d.User);
            return View(danhgias.ToList());
        }

        // GET: danhgias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhgia danhgia = db.danhgias.Find(id);
            if (danhgia == null)
            {
                return HttpNotFound();
            }
            return View(danhgia);
        }

        // GET: danhgias/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan");
            return View();
        }

        // POST: danhgias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dg_id,user_id,dg_value,ngaydg")] danhgia danhgia)
        {
            if (ModelState.IsValid)
            {
                db.danhgias.Add(danhgia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", danhgia.user_id);
            return View(danhgia);
        }

        // GET: danhgias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //danhgia danhgia = db.danhgias.Find(id);
            //if (id == null)
            //{
            //    return HttpNotFound();
            //}
            var customer = db.danhgias.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", customer.user_id);
            ViewBag.TrangThaiList = new SelectList(new[]
            {
               new { Value = 1, Text = "1 sao" },
               new { Value = 2, Text = "2 sao" },
               new { Value = 3, Text = "3 sao" },
               new { Value = 4, Text = "4 sao" },
               new { Value = 5, Text = "5 sao" },
            }, "Value", "Text", customer.dg_value);
            return View(customer);
        }

        // POST: danhgias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dg_id,user_id,dg_value,ngaydg")] danhgia danhgia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhgia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "taikhoan", danhgia.user_id);
            return View(danhgia);
        }

        // GET: danhgias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhgia danhgia = db.danhgias.Find(id);
            if (danhgia == null)
            {
                return HttpNotFound();
            }
            return View(danhgia);
        }

        // POST: danhgias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            danhgia danhgia = db.danhgias.Find(id);
            db.danhgias.Remove(danhgia);
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
