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
    public class PohadjanjeController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Pohadjanje
        public ActionResult Index()
        {
            //var pohadjanje = db.Pohadjanje.Include(p => p.Plan_i_program).Include(p => p.Profesor).Include(p => p.Student);
            //var v_Pohadjanje = db.v_Pohadjanje.Include(p => p.Student).Include(p => p.Profesor).Include(p => p.Predmet).Include(p => p.Akademska_godina);
            //return View(v_Pohadjanje.ToList());
            return View(db.v_Pohadjanje.ToList());
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
            ViewBag.ID_plan_i_program = new SelectList(db.Plan_i_program, "ID_plan_i_program", "ID_plan_i_program");
            ViewBag.ID_profesor = new SelectList(db.v_Profesor, "ID_Prof", "ProfIme");
            ViewBag.ID_Student = new SelectList(db.v_Student, "ID_student", "ImePrezime");
            ViewBag.ID_Predmet = new SelectList(db.Predmet, "ID_predmet", "Naziv");
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
            Predmet predmet = new Predmet();
            ViewBag.ID_plan_i_program = new SelectList(db.Plan_i_program, "ID_plan_i_program", "ID_plan_i_program", pohadjanje.ID_plan_i_program);
            ViewBag.ID_profesor = new SelectList(db.Profesor, "ID_Prof", "Ime"+" "+"Prezime", pohadjanje.ID_profesor);
            ViewBag.ID_predmet = new SelectList(db.Predmet, "ID_pred", "Naziv", predmet.ID_Predmet);
            ViewBag.ID_Student = new SelectList(db.Student, "ID_student", "JMBG", pohadjanje.ID_Student);
            return View(pohadjanje);
        }

        public ActionResult Create2(int ID_profesor,int ID_predmet, DateTime Datum,int ID_Student=0)
        {
            Pohadjanje pohadjanje = new Pohadjanje();
            pohadjanje.ID_Student = (int)Session["idstudent"];
            pohadjanje.ID_profesor = ID_profesor;
            //pohadjanje.ID_plan_i_program = ID_predmet;
            var predmeti=db.Plan_i_program.Where(m => m.ID_predmet == ID_predmet).ToList();
            if(predmeti.Count>0)
            {
                pohadjanje.ID_plan_i_program = predmeti.FirstOrDefault().ID_plan_i_program;
            }
            else
            {
                pohadjanje.ID_plan_i_program = null;
            }
            pohadjanje.Datum = Datum;
            if (ModelState.IsValid)
            {
                db.Pohadjanje.Add(pohadjanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Predmet predmet = new Predmet();
            ViewBag.ID_plan_i_program = new SelectList(db.Plan_i_program, "ID_plan_i_program", "ID_plan_i_program", pohadjanje.ID_plan_i_program);
            ViewBag.ID_profesor = new SelectList(db.Profesor, "ID_Prof", "Ime" + " " + "Prezime", pohadjanje.ID_profesor);
            ViewBag.ID_predmet = new SelectList(db.Predmet, "ID_pred", "Naziv", predmet.ID_Predmet);
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
