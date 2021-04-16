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
    public class Godina_StudijController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Godina_Studij
        public ActionResult Index()
        {
            var godina_Studij = db.Godina_Studij.Include(g => g.ID_Godina).Include(g => g.Studij).Include(g => g.Godina_Studij1).Include(g => g.Godina_Studij2);
            return View(godina_Studij.ToList());
        }

        // GET: Godina_Studij/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godina_Studij godina_Studij = db.Godina_Studij.Find(id);
            if (godina_Studij == null)
            {
                return HttpNotFound();
            }
            return View(godina_Studij);
        }

        // GET: Godina_Studij/Create
        public ActionResult Create()
        {
            ViewBag.ID_Godina = new SelectList(db.Godina, "ID_godina", "ID_godina");
            ViewBag.ID_Studij = new SelectList(db.Studij, "ID_studij", "Naziv");
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij");
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij");
            return View();
        }

        // POST: Godina_Studij/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Godina_Studij,ID_Godina,ID_Studij")] Godina_Studij godina_Studij)
        {
            if (ModelState.IsValid)
            {
                db.Godina_Studij.Add(godina_Studij);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Godina = new SelectList(db.Godina, "ID_godina", "ID_godina", godina_Studij.ID_Godina);
            ViewBag.ID_Studij = new SelectList(db.Studij, "ID_studij", "Naziv", godina_Studij.ID_Studij);
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", godina_Studij.ID_Godina_Studij);
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", godina_Studij.ID_Godina_Studij);
            return View(godina_Studij);
        }

        // GET: Godina_Studij/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godina_Studij godina_Studij = db.Godina_Studij.Find(id);
            if (godina_Studij == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Godina = new SelectList(db.Godina, "ID_godina", "ID_godina", godina_Studij.ID_Godina);
            ViewBag.ID_Studij = new SelectList(db.Studij, "ID_studij", "Naziv", godina_Studij.ID_Studij);
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", godina_Studij.ID_Godina_Studij);
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", godina_Studij.ID_Godina_Studij);
            return View(godina_Studij);
        }

        // POST: Godina_Studij/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Godina_Studij,ID_Godina,ID_Studij")] Godina_Studij godina_Studij)
        {
            if (ModelState.IsValid)
            {
                db.Entry(godina_Studij).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Godina = new SelectList(db.Godina, "ID_godina", "ID_godina", godina_Studij.ID_Godina);
            ViewBag.ID_Studij = new SelectList(db.Studij, "ID_studij", "Naziv", godina_Studij.ID_Studij);
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", godina_Studij.ID_Godina_Studij);
            ViewBag.ID_Godina_Studij = new SelectList(db.Godina_Studij, "ID_Godina_Studij", "ID_Godina_Studij", godina_Studij.ID_Godina_Studij);
            return View(godina_Studij);
        }

        // GET: Godina_Studij/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godina_Studij godina_Studij = db.Godina_Studij.Find(id);
            if (godina_Studij == null)
            {
                return HttpNotFound();
            }
            return View(godina_Studij);
        }

        // POST: Godina_Studij/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Godina_Studij godina_Studij = db.Godina_Studij.Find(id);
            db.Godina_Studij.Remove(godina_Studij);
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
