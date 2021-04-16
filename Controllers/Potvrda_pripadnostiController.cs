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
    public class Potvrda_pripadnostiController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Potvrda_pripadnosti
        public ActionResult Index()
        {
            return View(db.Potvrda_pripadnosti.ToList());
        }

        // GET: Potvrda_pripadnosti/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potvrda_pripadnosti potvrda_pripadnosti = db.Potvrda_pripadnosti.Find(id);
            if (potvrda_pripadnosti == null)
            {
                return HttpNotFound();
            }
            return View(potvrda_pripadnosti);
        }

        // GET: Potvrda_pripadnosti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Potvrda_pripadnosti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JMBG,Ime,Prezime,tip_studenta")] Potvrda_pripadnosti potvrda_pripadnosti)
        {
            if (ModelState.IsValid)
            {
                db.Potvrda_pripadnosti.Add(potvrda_pripadnosti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(potvrda_pripadnosti);
        }

        // GET: Potvrda_pripadnosti/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potvrda_pripadnosti potvrda_pripadnosti = db.Potvrda_pripadnosti.Find(id);
            if (potvrda_pripadnosti == null)
            {
                return HttpNotFound();
            }
            return View(potvrda_pripadnosti);
        }

        // POST: Potvrda_pripadnosti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JMBG,Ime,Prezime,tip_studenta")] Potvrda_pripadnosti potvrda_pripadnosti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potvrda_pripadnosti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(potvrda_pripadnosti);
        }

        // GET: Potvrda_pripadnosti/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potvrda_pripadnosti potvrda_pripadnosti = db.Potvrda_pripadnosti.Find(id);
            if (potvrda_pripadnosti == null)
            {
                return HttpNotFound();
            }
            return View(potvrda_pripadnosti);
        }

        // POST: Potvrda_pripadnosti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Potvrda_pripadnosti potvrda_pripadnosti = db.Potvrda_pripadnosti.Find(id);
            db.Potvrda_pripadnosti.Remove(potvrda_pripadnosti);
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
