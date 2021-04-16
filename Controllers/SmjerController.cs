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
    public class SmjerController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Smjer
        public ActionResult Index()
        {
            return View(db.Smjer.ToList());
        }

        // GET: Smjer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smjer smjer = db.Smjer.Find(id);
            if (smjer == null)
            {
                return HttpNotFound();
            }
            return View(smjer);
        }

        // GET: Smjer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Smjer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_smjer,Naziv")] Smjer smjer)
        {
            if (ModelState.IsValid)
            {
                db.Smjer.Add(smjer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smjer);
        }

        // GET: Smjer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smjer smjer = db.Smjer.Find(id);
            if (smjer == null)
            {
                return HttpNotFound();
            }
            return View(smjer);
        }

        // POST: Smjer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_smjer,Naziv")] Smjer smjer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smjer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smjer);
        }

        // GET: Smjer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smjer smjer = db.Smjer.Find(id);
            if (smjer == null)
            {
                return HttpNotFound();
            }
            return View(smjer);
        }

        // POST: Smjer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smjer smjer = db.Smjer.Find(id);
            db.Smjer.Remove(smjer);
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
