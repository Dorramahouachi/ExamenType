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
    public class CalendriersController : Controller
    {
        private ExamenContext db = new ExamenContext();

        // GET: Calendriers
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            using (ExamenContext dc = new ExamenContext())
            {
                var events = dc.Calendrier.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // GET: Calendriers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendrier calendrier = db.Calendrier.Find(id);
            if (calendrier == null)
            {
                return HttpNotFound();
            }
            return View(calendrier);
        }

        // GET: Calendriers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calendriers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalendrierId,Subject,Description,Start,End,ThemeColor,IsFullDay")] Calendrier calendrier)
        {
            if (ModelState.IsValid)
            {
                db.Calendrier.Add(calendrier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calendrier);
        }

        // GET: Calendriers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendrier calendrier = db.Calendrier.Find(id);
            if (calendrier == null)
            {
                return HttpNotFound();
            }
            return View(calendrier);
        }

        // POST: Calendriers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalendrierId,Subject,Description,Start,End,ThemeColor,IsFullDay")] Calendrier calendrier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendrier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calendrier);
        }

        // GET: Calendriers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendrier calendrier = db.Calendrier.Find(id);
            if (calendrier == null)
            {
                return HttpNotFound();
            }
            return View(calendrier);
        }

        // POST: Calendriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calendrier calendrier = db.Calendrier.Find(id);
            db.Calendrier.Remove(calendrier);
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
