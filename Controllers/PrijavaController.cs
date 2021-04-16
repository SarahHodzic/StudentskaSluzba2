using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using Studentska_Sluzba.App_Start;
using StudentskaSluzba2.App_Start;

namespace Studentska_Sluzba.Controllers
{
    public class PrijavaController : Controller
    {
        private Studentska_sluzbaEntities db = new Studentska_sluzbaEntities();

        // GET: Prijava
        public async Task<ActionResult> Index()
        {
            return View(await db.Prijava.ToListAsync());
        }

        // GET: Prijava/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = await db.Prijava.FindAsync(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // GET: Prijava/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prijava/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_Prijava,Korisnicko_ime,Lozinka,Email,Tip_Korisnika")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Prijava.Add(prijava);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(prijava);
        }

        // GET: Prijava/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = await db.Prijava.FindAsync(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // POST: Prijava/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_Prijava,Korisnicko_ime,Lozinka,Tip_Korisnika")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijava).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(prijava);
        }

        // GET: Prijava/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = await db.Prijava.FindAsync(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // POST: Prijava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prijava prijava = await db.Prijava.FindAsync(id);
            db.Prijava.Remove(prijava);
            await db.SaveChangesAsync();
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
        public ActionResult Registracija(string Korisnicko_ime, string Lozinka, string Email, string Ime, string Prezime, string JMBG, string Tip_Korisnika = "Student")
        {
           
            Student student = new Student();
            student.Ime = Ime;
            student.Prezime = Prezime;
            student.JMBG = JMBG;
            Prijava prijava = new Prijava();
            prijava.Korisnicko_ime = Korisnicko_ime;
            prijava.Lozinka = Lozinka;
            prijava.Email = Email;
            prijava.Tip_Korisnika = Tip_Korisnika;
            prijava.ID_student = student.ID_student;
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.Prijava.Add(prijava);
                //db.SaveChangesAsync();
                db.SaveChanges();
                // return RedirectToAction("Index", "Home");
                var data = db.Prijava.Where(s => s.Email.Equals(Email) && s.Lozinka.Equals(Lozinka)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().Korisnicko_ime;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().ID_Prijava;
                    Session["idstudent"] = data.FirstOrDefault().ID_student;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }

            }
            return View("/Home/Index");
        }
        public ActionResult Login(string Email, string Lozinka, string Tip_Korisnika = "Student")
        {
            if (ModelState.IsValid)
            {


                //                var f_password = GetMD5(Lozinka);
                var data = db.Prijava.Where(s => s.Email.Equals(Email) && s.Lozinka.Equals(Lozinka)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().Korisnicko_ime;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().ID_Prijava;
                    Session["idstudent"] = data.FirstOrDefault().ID_student;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Login failed";
                    return RedirectToAction("Login", "Home");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "Home");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        //public ActionResult Logiranje(string Korisnicko_ime, string Lozinka, string Tip_Korisnika = "Student")
        //{
        //    string prijavastate = "";
        //    Prijava prijava = new Prijava();
        //    prijava.Korisnicko_ime = Korisnicko_ime;
        //    prijava.Lozinka = Lozinka;
        //    prijava.Tip_Korisnika = Tip_Korisnika;
        //    prijavastate = db.Entry(prijava).State.ToString();
        //    if (db.Entry(prijava).State == EntityState.Detached)
        //    {

        //    }
        //    return View();
        //}
    }
}
