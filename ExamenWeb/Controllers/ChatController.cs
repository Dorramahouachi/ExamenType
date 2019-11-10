using Data;
using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class ChatController : Controller
    {
        private ExamenContext db = new ExamenContext();
        // GET: Chat
        public ActionResult Index()
        {
            return View(db.Chat.ToList());
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chat chat  = db.Chat.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        // GET: Chat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chat/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ChatId,SendId,ReceivedId,Contenu,vue,DateSend")] Chat chat)
        {
            if (ModelState.IsValid)
            {
                db.Chat.Add(chat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chat);
        }

        // GET: Chat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chat chat = db.Chat.Find(id);
            db.Chat.Remove(chat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
