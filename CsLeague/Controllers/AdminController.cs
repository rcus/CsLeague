using CsLeague.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CsLeague.Controllers
{
    public class AdminController : Controller
    {
        private CsLeagueContext db = new CsLeagueContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Clans.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clans clans = db.Clans.Find(id);
            if (clans == null)
            {
                return HttpNotFound();
            }
            return View(clans);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Origin")] Clans clans)
        {
            if (ModelState.IsValid)
            {
                db.Clans.Add(clans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clans);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clans clans = db.Clans.Find(id);
            if (clans == null)
            {
                return HttpNotFound();
            }
            return View(clans);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Origin")] Clans clans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clans);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clans clans = db.Clans.Find(id);
            if (clans == null)
            {
                return HttpNotFound();
            }
            return View(clans);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clans clans = db.Clans.Find(id);
            db.Clans.Remove(clans);
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
