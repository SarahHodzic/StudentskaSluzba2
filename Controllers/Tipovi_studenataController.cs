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
    public class Tipovi_studenataController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Tipovi_studenata
        public ActionResult Index()
        {
            var tipovi_studenata = db.Tipovi_studenata.Include(t => t.Student).Include(t => t.Student_tip);
            return View(tipovi_studenata.ToList());
        }

        // GET: Tipovi_studenata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipovi_studenata tipovi_studenata = db.Tipovi_studenata.Find(id);
            if (tipovi_studenata == null)
            {
                return HttpNotFound();
            }
            return View(tipovi_studenata);
        }

        // GET: Tipovi_studenata/Create
        public ActionResult Create()
        {
            ViewBag.ID_student = new SelectList(db.Student, "ID_student", "JMBG");
            ViewBag.ID_Student_tip = new SelectList(db.Student_tip, "ID_Student_tip", "Naziv");
            return View();
        }

        // POST: Tipovi_studenata/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Tipovi_studenata,ID_student,ID_Student_tip")] Tipovi_studenata tipovi_studenata)
        {
            if (ModelState.IsValid)
            {
                db.Tipovi_studenata.Add(tipovi_studenata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_student = new SelectList(db.Student, "ID_student", "JMBG", tipovi_studenata.ID_student);
            ViewBag.ID_Student_tip = new SelectList(db.Student_tip, "ID_Student_tip", "Naziv", tipovi_studenata.ID_Student_tip);
            return View(tipovi_studenata);
        }

        // GET: Tipovi_studenata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipovi_studenata tipovi_studenata = db.Tipovi_studenata.Find(id);
            if (tipovi_studenata == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_student = new SelectList(db.Student, "ID_student", "JMBG", tipovi_studenata.ID_student);
            ViewBag.ID_Student_tip = new SelectList(db.Student_tip, "ID_Student_tip", "Naziv", tipovi_studenata.ID_Student_tip);
            return View(tipovi_studenata);
        }

        // POST: Tipovi_studenata/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Tipovi_studenata,ID_student,ID_Student_tip")] Tipovi_studenata tipovi_studenata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipovi_studenata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_student = new SelectList(db.Student, "ID_student", "JMBG", tipovi_studenata.ID_student);
            ViewBag.ID_Student_tip = new SelectList(db.Student_tip, "ID_Student_tip", "Naziv", tipovi_studenata.ID_Student_tip);
            return View(tipovi_studenata);
        }

        // GET: Tipovi_studenata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipovi_studenata tipovi_studenata = db.Tipovi_studenata.Find(id);
            if (tipovi_studenata == null)
            {
                return HttpNotFound();
            }
            return View(tipovi_studenata);
        }

        // POST: Tipovi_studenata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipovi_studenata tipovi_studenata = db.Tipovi_studenata.Find(id);
            db.Tipovi_studenata.Remove(tipovi_studenata);
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
