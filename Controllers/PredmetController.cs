﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentskaSluzba2.App_Start;

namespace StudentskaSluzba2.Controllers
{
    public class PredmetController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Predmet
        public ActionResult Index()
        {
            return View(db.Predmet.ToList());
        }

        // GET: Predmet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmet.Find(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // GET: Predmet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predmet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Predmet,Naziv")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                db.Predmet.Add(predmet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predmet);
        }

        // GET: Predmet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmet.Find(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // POST: Predmet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Predmet,Naziv")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predmet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predmet);
        }

        // GET: Predmet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = db.Predmet.Find(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // POST: Predmet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predmet predmet = db.Predmet.Find(id);
            db.Predmet.Remove(predmet);
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
