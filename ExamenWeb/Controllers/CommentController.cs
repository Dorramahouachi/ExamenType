﻿using Data;
using Domaine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class CommentController : Controller
    {
        private ExamenContext db = new ExamenContext();
        // GET: Comment
        public ActionResult IndexC(int? PostId)
        {
            return View(db.Comment.Where(com => com.PostId == PostId).ToList());
        }

        public ActionResult Index()
        {
            return View(db.Comment.ToList());
        }

        // GET: Post


        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }





        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "CommentId,contenu,dateComment,PostId,UserId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comment.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }



        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }






        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,contenu,dateComment")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Comment comment = db.Comment.Find(id);
                if (comment == null)
                {
                    return HttpNotFound();
                }
                return View(comment);
        }
        
        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comment.Find(id);
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
