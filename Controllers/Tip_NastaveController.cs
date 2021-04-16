using System;
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
    public class Tip_NastaveController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Tip_Nastave
        public ActionResult Index()
        {
            return View(db.Tip_Nastave.ToList());
        }

        // GET: Tip_Nastave/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip_Nastave tip_Nastave = db.Tip_Nastave.Find(id);
            if (tip_Nastave == null)
            {
                return HttpNotFound();
            }
            return View(tip_Nastave);
        }

        // GET: Tip_Nastave/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tip_Nastave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_tip,Tip")] Tip_Nastave tip_Nastave)
        {
            if (ModelState.IsValid)
            {
                db.Tip_Nastave.Add(tip_Nastave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tip_Nastave);
        }

        // GET: Tip_Nastave/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip_Nastave tip_Nastave = db.Tip_Nastave.Find(id);
            if (tip_Nastave == null)
            {
                return HttpNotFound();
            }
            return View(tip_Nastave);
        }

        // POST: Tip_Nastave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_tip,Tip")] Tip_Nastave tip_Nastave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tip_Nastave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tip_Nastave);
        }

        // GET: Tip_Nastave/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip_Nastave tip_Nastave = db.Tip_Nastave.Find(id);
            if (tip_Nastave == null)
            {
                return HttpNotFound();
            }
            return View(tip_Nastave);
        }

        // POST: Tip_Nastave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tip_Nastave tip_Nastave = db.Tip_Nastave.Find(id);
            db.Tip_Nastave.Remove(tip_Nastave);
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
