using Data;
using Domaine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace ExamenWeb.Controllers
{
    public class ReactPostController : Controller
    {
        private ExamenContext db = new ExamenContext();
        // GET: ReactPost
        public ActionResult Index()
        {
            return View(db.ReactPost.ToList());
        }

        // GET: ReactPost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReactPost reactpost = db.ReactPost.Find(id);
            if (reactpost == null)
            {
                return HttpNotFound();
            }
            return View(reactpost);
        }


        public int Count(int? PostId)
        { int nb = db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == "Like").ToList().Count();
            return nb; 
        }

        public int CountD(int? PostId)
        {
            return db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == "Dislike").ToList().Count();
        }

        public int Test(int? UserId,int? PostId)
        {
             int test =db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.UserId == UserId)
                .Where(emp => emp.TypeReact == "Dislike").ToList().Count();
            return test;
        }

       

        [HttpGet]
        public  ActionResult ListL()
        {
            
            return PartialView(db.ReactPost.Where(emp => emp.TypeReact == "Like").ToList());


        }



        public int TestD(int? UserId, int? PostId)
        {
            int test = db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.UserId == UserId)
               .Where(emp => emp.TypeReact == "like").ToList().Count();
            return test;
        }


        // GET: ReactPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReactPost/Create
        [HttpPost]
        public int Create(int? PostId , int? UserId , String TypeReact ,[Bind(Include = "PostId,typeReact,PostId,UserId")] ReactPost reactpost)
        {

            if (ModelState.IsValid)
            {
                reactpost.UserId = UserId;
                reactpost.PostId = PostId;
                reactpost.TypeReact = TypeReact;
                db.ReactPost.Add(reactpost);
                db.SaveChanges();
               
            }

            return db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == TypeReact).ToList().Count();
        }


        // GET: ReactPost/CreateDel
        public ActionResult CreateDel()
        {
            return View();
        }

        [HttpPost]
       
        public int CreateDel(int? PostId, int? UserId, String TypeReact, [Bind(Include = "PostId,typeReact,PostId,UserId")] ReactPost reactpost)
        {

            if (ModelState.IsValid)
            {
                reactpost.UserId = UserId;
                reactpost.PostId = PostId;
                reactpost.TypeReact = TypeReact;
                db.ReactPost.Add(reactpost);
                db.SaveChanges();

           

          
            }
            db.ReactPost.RemoveRange(db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == "Dislike")
              .Where(emp => emp.UserId == UserId));
            db.SaveChanges();
            return db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == TypeReact).ToList().Count();
        }


        // GET: ReactPost/CreateDel
        public ActionResult CreateDelD()
        {
            return View();
        }

        [HttpPost]

        public int CreateDelD(int? PostId, int? UserId, String TypeReact, [Bind(Include = "PostId,typeReact,PostId,UserId")] ReactPost reactpost)
        {

            if (ModelState.IsValid)
            {
                reactpost.UserId = UserId;
                reactpost.PostId = PostId;
                reactpost.TypeReact = TypeReact;
                db.ReactPost.Add(reactpost);
                db.SaveChanges();




            }
            db.ReactPost.RemoveRange(db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == "Like")
              .Where(emp => emp.UserId == UserId));
            db.SaveChanges();
            return db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == TypeReact).ToList().Count();
        }






        // GET: ReactPost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReactPost/Edit/5
    /*    [HttpPost]
        public int Edit(int? PostId, int? UserId, String TypeReact, [Bind(Include = "PostId,typeReact,PostId,UserId")] ReactPost reactpost)
        {
            if (ModelState.IsValid)
            {
                reactpost.UserId = UserId;
                reactpost.PostId = PostId;
                reactpost.TypeReact = TypeReact;
                db.ReactPost.Add(reactpost);
                db.SaveChanges();

            }

            return db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == TypeReact);

        }
        */
        // GET: ReactPost/Delete/5
        public ActionResult Delete(int? PostId, int? UserId, String TypeReact)
        {
            return View();
        }

        // POST: ReactPost/Delete/5
        [HttpPost]
     
        public int DeleteConfirmed(int? PostId, int? UserId, String TypeReact)
        {
            db.ReactPost.RemoveRange(db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == TypeReact)
               .Where(emp => emp.UserId == UserId));
            db.SaveChanges();
            return db.ReactPost.Where(emp => emp.PostId == PostId).Where(emp => emp.TypeReact == TypeReact).ToList().Count();

        }
    }
}
