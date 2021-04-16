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
    public class ZalbaController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Zalba
        public ActionResult Index()
        {
            var zalba = db.Zalba.Include(z => z.Student);
            return View(zalba.ToList());
        }

        // GET: Zalba/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zalba zalba = db.Zalba.Find(id);
            if (zalba == null)
            {
                return HttpNotFound();
            }
            return View(zalba);
        }

        // GET: Zalba/Create
        public ActionResult Create()
        {
            ViewBag.ID_Student = new SelectList(db.Student, "ID_student", "Ime");
            ViewBag.ID_Student1 = new SelectList(db.Student, "ID_student", "Prezime");
            return View();
        }

        // POST: Zalba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Zalba,ID_Student")] Zalba zalba)
        {
            if (ModelState.IsValid)
            {
                db.Zalba.Add(zalba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Student = new SelectList(db.Student, "ID_student", "Ime", zalba.ID_Student);
            ViewBag.ID_Student1 = new SelectList(db.Student, "ID_student", "Prezime", zalba.ID_Student);
            return View(zalba);
        }

        // GET: Zalba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zalba zalba = db.Zalba.Find(id);
            if (zalba == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Student = new SelectList(db.Student, "ID_student", "JMBG", zalba.ID_Student);
            return View(zalba);
        }

        // POST: Zalba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Zalba,ID_Student")] Zalba zalba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zalba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Student = new SelectList(db.Student, "ID_student", "JMBG", zalba.ID_Student);
            return View(zalba);
        }

        // GET: Zalba/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zalba zalba = db.Zalba.Find(id);
            if (zalba == null)
            {
                return HttpNotFound();
            }
            return View(zalba);
        }

        // POST: Zalba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zalba zalba = db.Zalba.Find(id);
            db.Zalba.Remove(zalba);
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
