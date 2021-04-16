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
    public class StudijController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Studij
        public ActionResult Index()
        {
            var studij = db.Studij.Include(s => s.Smjer);
            return View(studij.ToList());
        }

        // GET: Studij/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studij studij = db.Studij.Find(id);
            if (studij == null)
            {
                return HttpNotFound();
            }
            return View(studij);
        }

        // GET: Studij/Create
        public ActionResult Create()
        {
            ViewBag.ID_smjer = new SelectList(db.Smjer, "ID_smjer", "Naziv");
            return View();
        }

        // POST: Studij/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_studij,Naziv,ID_smjer")] Studij studij)
        {
            if (ModelState.IsValid)
            {
                db.Studij.Add(studij);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_smjer = new SelectList(db.Smjer, "ID_smjer", "Naziv", studij.ID_smjer);
            return View(studij);
        }

        // GET: Studij/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studij studij = db.Studij.Find(id);
            if (studij == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_smjer = new SelectList(db.Smjer, "ID_smjer", "Naziv", studij.ID_smjer);
            return View(studij);
        }

        // POST: Studij/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_studij,Naziv,ID_smjer")] Studij studij)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studij).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_smjer = new SelectList(db.Smjer, "ID_smjer", "Naziv", studij.ID_smjer);
            return View(studij);
        }

        // GET: Studij/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studij studij = db.Studij.Find(id);
            if (studij == null)
            {
                return HttpNotFound();
            }
            return View(studij);
        }

        // POST: Studij/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studij studij = db.Studij.Find(id);
            db.Studij.Remove(studij);
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
