using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domaine;

namespace ExamenWeb.Controllers
{
    public class CandidaturesController : Controller
    {
        private ExamenContext db = new ExamenContext();

        // GET: Candidatures
        public ActionResult Index()
        {
            var candidature = db.Candidature.Include(c => c.Users);
            return View(candidature.ToList());
        }
        // GET: Candidatures
        public ActionResult CandidatCandidatures()
        {
            var candidature = db.Candidature.Include(c => c.Users);
            return View(candidature.ToList());
        }

        // GET: Candidatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidature candidature = db.Candidature.Find(id);
            if (candidature == null)
            {
                return HttpNotFound();
            }
            return View(candidature);
        }

        // GET: Candidatures/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "login");
            return View();
        }

        // POST: Candidatures/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "candidatureId,UserId,candidatureDate,etat")] Candidature candidature)
        {
            if (ModelState.IsValid)
            {
                db.Candidature.Add(candidature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "login", candidature.UserId);
            return View(candidature);
        }

        // GET: Candidatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidature candidature = db.Candidature.Find(id);
            if (candidature == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "login", candidature.UserId);
            return View(candidature);
        }

        // POST: Candidatures/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "candidatureId,UserId,candidatureDate,etat")] Candidature candidature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "login", candidature.UserId);
            return View(candidature);
        }

        // GET: Candidatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidature candidature = db.Candidature.Find(id);
            if (candidature == null)
            {
                return HttpNotFound();
            }
            return View(candidature);
        }

        // POST: Candidatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidature candidature = db.Candidature.Find(id);
            db.Candidature.Remove(candidature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("EtatCandidature")]
        public ActionResult EtatCandidature(int id)
        {
            /*  Candidature candidature = db.Candidature.Find(id);
              candidature.etat = Candidature.etatCandidature.accepted;
              db.SaveChanges();*/

            Candidature candidature = db.Candidature.Find(id);
            if(candidature.etat == Candidature.etatCandidature.Quizz)
            {
                return RedirectToAction("~/Question/Index");

            }
            else if(candidature.etat== Candidature.etatCandidature.accepted)
            {
                return RedirectToAction("~/Calendriers/Index");
     
            }
            else
            return RedirectToAction("~/CandidatCandidatures");
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
