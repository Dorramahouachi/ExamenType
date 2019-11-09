using Data;
using Domaine;
using ExamenWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
   
    public class PostController : Controller
    {
        private ExamenContext db = new ExamenContext();
        // GET: Post
        public ActionResult Index()
        {
            var mymodel = new Multi();
            mymodel.postdetails = db.Post.ToList();
            mymodel.reactdetails = db.ReactPost.ToList();
            return View(mymodel);
        }


        public int Vue(int? PostId)
        {

            Post post = db.Post.Find(PostId);
            post.vue=post.vue+1;
            db.SaveChanges();
            return 1;

        }

        // GET: Post
        public ActionResult Recent()
        {
            var mymodel = new Multi();
            mymodel.postdetails = db.Post.OrderByDescending(news => news.DatePost).ToList();
            mymodel.reactdetails = db.ReactPost.ToList();
            return View  (mymodel);
        }


        // GET: Post
        public ActionResult Vues()
        {
            var mymodel = new Multi();
            mymodel.postdetails = db.Post.OrderByDescending(news => news.vue).ToList();
            mymodel.reactdetails = db.ReactPost.ToList();
            return View(mymodel);
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = db.Post.Find(id);
          
            if (post == null)
            {
                return HttpNotFound();
            }
            return PartialView(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "PostId,contenu,datePost,vue,UserId")] Post post)
        {
            if (ModelState.IsValid)
                {   
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Post/Edit/5²        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,contenu,datePost,UserId,vue")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.UserId = 2;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return PartialView(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
      
        public ActionResult DeleteP(int? PostId)
        {
            Post post = db.Post.Find(PostId);
            db.Post.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public void uploadnow(HttpPostedFileWrapper upload)
        {
            if (upload != null)
            {
                string ImageName = upload.FileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/uploads"), ImageName);
                upload.SaveAs(path);
            }

        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string url; // url to return
            string message; // message to display (optional)
            message = "Image successfully saved ";

            //do save image code here
            url = "/" + Server.MapPath("~/Images/uploads") + "/" + upload.FileName;
            string output = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\", \"" + message + "\");</script></body></html>";

            return Content(output);
        }


    }
}

