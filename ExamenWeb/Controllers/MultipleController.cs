using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenWeb.Models;
using Data;
using Domaine;
using System.Net;
using System.Data.Entity;

namespace ExamenWeb.Controllers
{
    public class MultipleController : Controller
    {
        private ExamenContext db = new ExamenContext();
        // GET: Comment
        // GET: Multip
        
        public ActionResult Index( int? PostId)
        {
            var mymodel = new Multiple();
            mymodel.commentdetails = db.Comment.Where(com => com.PostId == PostId).ToList();
            mymodel.postdetails = db.Post.Where(pos => pos.PostId == PostId).ToList();
                //db.Post.Where(pos => pos.PostId == PostId).ToList();

           

            return View(mymodel);
           
        }





        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(int? PostId , [Bind(Include = "CommentId,contenu,dateComment,PostId,UserId")] Comment comment)
        {
            
            if (ModelState.IsValid)
            {
               
                db.Comment.Add(comment);
               
                db.SaveChanges();
                return RedirectToAction("Index",new { PostId=PostId});
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
        public ActionResult Edit([Bind(Include = "CommentId,contenu,dateComment,UserId,PostId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.UserId = 2;
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { PostId = comment.PostId });
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

        // POST: Multiple/Delete/5
        [HttpPost]

        public ActionResult DeleteC(int? CommentId)
        {
            Comment comment = db.Comment.Find(CommentId);
            var id = comment.PostId;
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index", new { PostId = id });
        }
    }
}