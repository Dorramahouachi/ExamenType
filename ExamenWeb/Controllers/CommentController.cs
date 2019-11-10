using Data;
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
        [ValidateInput(false)]
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
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "CommentId,contenu,dateComment")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.UserId = 2;
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { PostId = comment.PostId });
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
        [HttpPost]
  
        public ActionResult DeleteC(int? CommentId)
        {
            Comment comment = db.Comment.Find(CommentId);
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index",new { PostId=comment.PostId});
        }


        [HttpGet]
        public PartialViewResult ListL(int? CommentId)
        {

            List<ReactComment> listr = db.ReactComment.Where(emp => emp.TypeReact == "Like").Where(emp => emp.CommentId == CommentId).ToList();
            ViewBag.ReactList = listr;

            return PartialView(listr);


        }


        [HttpGet]
        public PartialViewResult ListD(int? CommentId)
        {

            List<ReactComment> listr = db.ReactComment.Where(emp => emp.TypeReact == "Dislike").Where(emp => emp.CommentId == CommentId).ToList();
            ViewBag.ReactList = listr;

            return PartialView(listr);


        }

    }
}
