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
    public class Plan_i_programController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Plan_i_program
        public ActionResult Index()
        {
            var plan_i_program = db.Plan_i_program.Include(p => p.ID_Godina_Studij).Include(p => p.Predmet).Include(p => p.Tip_Nastave);
            return View(plan_i_program.ToList());
        }

        // GET: Plan_i_program/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_i_program plan_i_program = db.Plan_i_program.Find(id);
            if (plan_i_program == null)
            {
                return HttpNotFound();
            }
            return View(plan_i_program);
        }

        // GET: Plan_i_program/Create
        public ActionResult Create()
        {
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij");
            ViewBag.ID_predmet = new SelectList(db.Predmet, "ID_Predmet", "Naziv");
            ViewBag.ID_tipn = new SelectList(db.Tip_Nastave, "ID_tip", "Tip");
            return View();
        }

        // POST: Plan_i_program/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_plan_i_program,ID_predmet,ID_tipn,ID_Godina_Studij")] Plan_i_program plan_i_program)
        {
            if (ModelState.IsValid)
            {
                db.Plan_i_program.Add(plan_i_program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", plan_i_program.ID_Godina_Studij);
            ViewBag.ID_predmet = new SelectList(db.Predmet, "ID_Predmet", "Naziv", plan_i_program.ID_predmet);
            ViewBag.ID_tipn = new SelectList(db.Tip_Nastave, "ID_tip", "Tip", plan_i_program.ID_tipn);
            return View(plan_i_program);
        }

        // GET: Plan_i_program/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_i_program plan_i_program = db.Plan_i_program.Find(id);
            if (plan_i_program == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", plan_i_program.ID_Godina_Studij);
            ViewBag.ID_predmet = new SelectList(db.Predmet, "ID_Predmet", "Naziv", plan_i_program.ID_predmet);
            ViewBag.ID_tipn = new SelectList(db.Tip_Nastave, "ID_tip", "Tip", plan_i_program.ID_tipn);
            return View(plan_i_program);
        }

        // POST: Plan_i_program/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_plan_i_program,ID_predmet,ID_tipn,ID_Godina_Studij")] Plan_i_program plan_i_program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_i_program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", plan_i_program.ID_Godina_Studij);
            ViewBag.ID_predmet = new SelectList(db.Predmet, "ID_Predmet", "Naziv", plan_i_program.ID_predmet);
            ViewBag.ID_tipn = new SelectList(db.Tip_Nastave, "ID_tip", "Tip", plan_i_program.ID_tipn);
            return View(plan_i_program);
        }

        // GET: Plan_i_program/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_i_program plan_i_program = db.Plan_i_program.Find(id);
            if (plan_i_program == null)
            {
                return HttpNotFound();
            }
            return View(plan_i_program);
        }

        // POST: Plan_i_program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan_i_program plan_i_program = db.Plan_i_program.Find(id);
            db.Plan_i_program.Remove(plan_i_program);
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
