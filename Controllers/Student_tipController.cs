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
    public class Student_tipController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Student_tip
        public ActionResult Index()
        {
            return View(db.Student_tip.ToList());
        }

        // GET: Student_tip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_tip student_tip = db.Student_tip.Find(id);
            if (student_tip == null)
            {
                return HttpNotFound();
            }
            return View(student_tip);
        }

        // GET: Student_tip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student_tip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Student_tip,Naziv")] Student_tip student_tip)
        {
            if (ModelState.IsValid)
            {
                db.Student_tip.Add(student_tip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_tip);
        }

        // GET: Student_tip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_tip student_tip = db.Student_tip.Find(id);
            if (student_tip == null)
            {
                return HttpNotFound();
            }
            return View(student_tip);
        }

        // POST: Student_tip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Student_tip,Naziv")] Student_tip student_tip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_tip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_tip);
        }

        // GET: Student_tip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_tip student_tip = db.Student_tip.Find(id);
            if (student_tip == null)
            {
                return HttpNotFound();
            }
            return View(student_tip);
        }

        // POST: Student_tip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_tip student_tip = db.Student_tip.Find(id);
            db.Student_tip.Remove(student_tip);
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
