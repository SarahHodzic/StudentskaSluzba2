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
    public class PohadjanjeController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Pohadjanje
        public ActionResult Index()
        {
            var pohadjanje = db.Pohadjanje.Include(p => p.Plan_i_program).Include(p => p.Profesor).Include(p => p.Student);
            return View(pohadjanje.ToList());
        }

        // GET: Pohadjanje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pohadjanje pohadjanje = db.Pohadjanje.Find(id);
            if (pohadjanje == null)
            {
                return HttpNotFound();
            }
            return View(pohadjanje);
        }

        // GET: Pohadjanje/Create
        public ActionResult Create()
        {
            ViewBag.ID_plan_i_program = new SelectList(db.Plan_i_program, "ID_predmet", "Naziv");
            ViewBag.ID_profesor = new SelectList(db.Profesor, "ID_Prof", "Ime","Prezime");
            ViewBag.ID_Student = new SelectList(db.Student, "ID_Student", "Prezime");
     
            return View();
        }

        // POST: Pohadjanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Pohadjanje,ID_Student,ID_profesor,ID_plan_i_program,Datum")] Pohadjanje pohadjanje)
        {
            if (ModelState.IsValid)
            {
                db.Pohadjanje.Add(pohadjanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_plan_i_program = new SelectList(db.Plan_i_program, "ID_plan_i_program", "ID_plan_i_program", pohadjanje.ID_plan_i_program);
            ViewBag.ID_profesor = new SelectList(db.Profesor, "ID_Prof", "Ime", pohadjanje.ID_profesor);
            ViewBag.ID_Student = new SelectList(db.Student, "ID_student", "JMBG", pohadjanje.ID_Student);
            return View(pohadjanje);
        }

        // GET: Pohadjanje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pohadjanje pohadjanje = db.Pohadjanje.Find(id);
            if (pohadjanje == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_plan_i_program = new SelectList(db.Plan_i_program, "ID_plan_i_program", "ID_plan_i_program", pohadjanje.ID_plan_i_program);
            ViewBag.ID_profesor = new SelectList(db.Profesor, "ID_Prof", "Ime", pohadjanje.ID_profesor);
            ViewBag.ID_Student = new SelectList(db.Student, "ID_student", "JMBG", pohadjanje.ID_Student);
            return View(pohadjanje);
        }

        // POST: Pohadjanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Pohadjanje,ID_Student,ID_profesor,ID_plan_i_program,Datum")] Pohadjanje pohadjanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pohadjanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_plan_i_program = new SelectList(db.Plan_i_program, "ID_plan_i_program", "ID_plan_i_program", pohadjanje.ID_plan_i_program);
            ViewBag.ID_profesor = new SelectList(db.Profesor, "ID_Prof", "Ime", pohadjanje.ID_profesor);
            ViewBag.ID_Student = new SelectList(db.Student, "ID_student", "JMBG", pohadjanje.ID_Student);
            return View(pohadjanje);
        }

        // GET: Pohadjanje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pohadjanje pohadjanje = db.Pohadjanje.Find(id);
            if (pohadjanje == null)
            {
                return HttpNotFound();
            }
            return View(pohadjanje);
        }

        // POST: Pohadjanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pohadjanje pohadjanje = db.Pohadjanje.Find(id);
            db.Pohadjanje.Remove(pohadjanje);
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
