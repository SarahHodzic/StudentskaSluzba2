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
    public class v_PohadjanjeController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: v_Pohadjanje
        public ActionResult Index()
        {
            return View(db.v_Pohadjanje.ToList());
        }

        // GET: v_Pohadjanje/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_Pohadjanje v_Pohadjanje = db.v_Pohadjanje.Find(id);
            if (v_Pohadjanje == null)
            {
                return HttpNotFound();
            }
            return View(v_Pohadjanje);
        }

        // GET: v_Pohadjanje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v_Pohadjanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student,Profesor,Predmet,Akademska_godina")] v_Pohadjanje v_Pohadjanje)
        {
            if (ModelState.IsValid)
            {
                db.v_Pohadjanje.Add(v_Pohadjanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_Pohadjanje);
        }

        // GET: v_Pohadjanje/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_Pohadjanje v_Pohadjanje = db.v_Pohadjanje.Find(id);
            if (v_Pohadjanje == null)
            {
                return HttpNotFound();
            }
            return View(v_Pohadjanje);
        }

        // POST: v_Pohadjanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student,Profesor,Predmet,Akademska_godina")] v_Pohadjanje v_Pohadjanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_Pohadjanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_Pohadjanje);
        }

        // GET: v_Pohadjanje/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_Pohadjanje v_Pohadjanje = db.v_Pohadjanje.Find(id);
            if (v_Pohadjanje == null)
            {
                return HttpNotFound();
            }
            return View(v_Pohadjanje);
        }

        // POST: v_Pohadjanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            v_Pohadjanje v_Pohadjanje = db.v_Pohadjanje.Find(id);
            db.v_Pohadjanje.Remove(v_Pohadjanje);
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
