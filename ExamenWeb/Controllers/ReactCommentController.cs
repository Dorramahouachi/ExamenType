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
    public class ReactCommentController : Controller
    {
        private ExamenContext db = new ExamenContext();
        // GET: ReactComment
        public ActionResult Index()
        {
            return View(db.ReactComment.ToList());
        }

        // GET: ReactComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReactComment reactcomment = db.ReactComment.Find(id);
            if (reactcomment == null)
            {
                return HttpNotFound();
            }
            return View(reactcomment);
        }

        // GET: ReactComment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReactComment/Create
        [HttpPost]
        public int Create(int? CommentId, int? UserId, String TypeReact ,[Bind(Include = "ReactCommentId,TypeReact,CommentId,UserId")] ReactComment reactcomment)
        {
            if (ModelState.IsValid)
            {
                reactcomment.UserId = UserId;
                reactcomment.CommentId = CommentId;
                reactcomment.TypeReact = TypeReact;
                db.ReactComment.Add(reactcomment);
                db.SaveChanges();


            }

            return db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == TypeReact).ToList().Count();

        }

        // GET: ReactComment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReactComment/Edit/5
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

        // GET: ReactComment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReactComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReactComment reactcomment = db.ReactComment.Find(id);
            db.ReactComment.Remove(reactcomment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }






        public int Count(int? CommentId)
        {
            int nb = db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == "Like").ToList().Count();
            return nb;
        }

        public int CountD(int? CommentId)
        {
            return db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == "Dislike").ToList().Count();
        }

        public int Test(int? UserId, int? CommentId)
        {
            int test = db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.UserId == UserId)
               .Where(emp => emp.TypeReact == "Dislike").ToList().Count();
            return test;
        }

        public int TestD(int? UserId, int? CommentId)
        {
            int test = db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.UserId == UserId)
               .Where(emp => emp.TypeReact == "like").ToList().Count();
            return test;
        }


        // GET: ReactComment/CreateDel
        public ActionResult CreateDel()
        {
            return View();
        }

        [HttpPost]

        public int CreateDel(int? CommentId, int? UserId, String TypeReact, [Bind(Include = "ReactCommentId,TypeReact,CommentId,UserId")] ReactComment reactcomment)
        {

            if (ModelState.IsValid)
            {
                reactcomment.UserId = UserId;
                reactcomment.CommentId = CommentId;
                reactcomment.TypeReact = TypeReact;
                db.ReactComment.Add(reactcomment);
                db.SaveChanges();




            }
            db.ReactComment.RemoveRange(db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == "Dislike")
              .Where(emp => emp.UserId == UserId));
            db.SaveChanges();
            return db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == TypeReact).ToList().Count();
        }





        // GET: ReactPost/CreateDel
        public ActionResult CreateDelD()
        {
            return View();
        }

        [HttpPost]

        public int CreateDelD(int? CommentId, int? UserId, String TypeReact, [Bind(Include = "ReactCommentId,TypeReact,CommentId,UserId")] ReactComment reactcomment)
        {

            if (ModelState.IsValid)
            {
                reactcomment.UserId = UserId;
                reactcomment.CommentId = CommentId;
                reactcomment.TypeReact = TypeReact;
                db.ReactComment.Add(reactcomment);
                db.SaveChanges();




            }
            db.ReactComment.RemoveRange(db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == "Like")
              .Where(emp => emp.UserId == UserId));
            db.SaveChanges();
            return db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == TypeReact).ToList().Count();
        }




        [HttpPost]

        public int DeleteConfirmed(int? CommentId, int? UserId, String TypeReact)
        {
            db.ReactComment.RemoveRange(db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == TypeReact)
               .Where(emp => emp.UserId == UserId));
            db.SaveChanges();
            return db.ReactComment.Where(emp => emp.CommentId == CommentId).Where(emp => emp.TypeReact == TypeReact).ToList().Count();

        }

    }
}
