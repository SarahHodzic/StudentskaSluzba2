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
    public class GodinaController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Godina
        public ActionResult Index()
        {
            var godinas = db.Godina.Include(g => g.Studij);
            return View(godinas.ToList());
        }

        // GET: Godina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godina godina = db.Godina.Find(id);
            if (godina == null)
            {
                return HttpNotFound();
            }
            return View(godina);
        }

        // GET: Godina/Create
        public ActionResult Create()
        {
            ViewBag.ID_studij = new SelectList(db.Studij, "ID_studij", "Naziv");
            return View();
        }

        // POST: Godina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_godina,ID_studij")] Godina godina)
        {
            if (ModelState.IsValid)
            {
                db.Godina.Add(godina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_studij = new SelectList(db.Studij, "ID_studij", "Naziv", godina.ID_studij);
            return View(godina);
        }

        // GET: Godina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godina godina = db.Godina.Find(id);
            if (godina == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_studij = new SelectList(db.Studij, "ID_studij", "Naziv", godina.ID_studij);
            return View(godina);
        }

        // POST: Godina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_godina,ID_studij")] Godina godina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(godina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_studij = new SelectList(db.Studij, "ID_studij", "Naziv", godina.ID_studij);
            return View(godina);
        }

        // GET: Godina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godina godina = db.Godina.Find(id);
            if (godina == null)
            {
                return HttpNotFound();
            }
            return View(godina);
        }

        // POST: Godina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Godina godina = db.Godina.Find(id);
            db.Godina.Remove(godina);
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
