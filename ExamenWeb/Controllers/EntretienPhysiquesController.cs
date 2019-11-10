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
    public class EntretienPhysiquesController : Controller
    {
        private ExamenContext db = new ExamenContext();

        // GET: EntretienPhysiques
        public ActionResult Index()
        {
            return View(db.EntretienPhysique.ToList());
        }

        // GET: EntretienPhysiques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntretienPhysique entretienPhysique = db.EntretienPhysique.Find(id);
            if (entretienPhysique == null)
            {
                return HttpNotFound();
            }
            return View(entretienPhysique);
        }

        // GET: EntretienPhysiques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntretienPhysiques/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntretienPhysiqueId,DateEntretien")] EntretienPhysique entretienPhysique)
        {
            if (ModelState.IsValid)
            {
                db.EntretienPhysique.Add(entretienPhysique);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entretienPhysique);
        }

        // GET: EntretienPhysiques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntretienPhysique entretienPhysique = db.EntretienPhysique.Find(id);
            if (entretienPhysique == null)
            {
                return HttpNotFound();
            }
            return View(entretienPhysique);
        }

        // POST: EntretienPhysiques/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntretienPhysiqueId,DateEntretien")] EntretienPhysique entretienPhysique)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entretienPhysique).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entretienPhysique);
        }

        // GET: EntretienPhysiques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntretienPhysique entretienPhysique = db.EntretienPhysique.Find(id);
            if (entretienPhysique == null)
            {
                return HttpNotFound();
            }
            return View(entretienPhysique);
        }

        // POST: EntretienPhysiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntretienPhysique entretienPhysique = db.EntretienPhysique.Find(id);
            db.EntretienPhysique.Remove(entretienPhysique);
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
