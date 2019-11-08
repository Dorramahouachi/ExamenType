using Data;
using Data.Infrastructure;
using Domaine;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ExamenWeb.DAL;
using ExamenWeb.Models;
using ExamenWeb.Security;

namespace ExamenWeb.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    [Authorize]
    public class AdminController : BaseController
    {



        AdminViewModel viewModel = new AdminViewModel();
        IUserService userService = new UserService();
        IRoleService roleService = new RoleService();
        // GET: Admin

        public ActionResult Index()
        {

            viewModel.Users = userService.GetMany().ToList();

            viewModel.Roles = ww.Roles.ToList();

            return View(viewModel);
        }



        // GET: Users/Details/5
        public ActionResult DetailsUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userService.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("User/Details", user);
        }

        // GET: Users/Create
        public ActionResult CreateUser()
        {
            ViewBag.RoleId = new SelectList(roleService.GetMany(), "RoleId", "RoleName");
            return View("User/Create");
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include = "UserId,Username,Email,Password,FirstName,LastName,IsActive,CreateDate")] User user)
        {
            if (ModelState.IsValid)
            {

                int roleId = int.Parse(Request["RoleId"]);
                WebContext ctx = new WebContext();
                User u = new User();
                u.Username = user.Username;
                u.Email = user.Email;
                u.FirstName = user.FirstName;
                u.Password = user.Password;
                u.CreateDate = DateTime.Now;
                u.IsActive = false;
                var roleuser = ctx.Roles.Single(r => r.RoleId == roleId);
                u.Roles = new List<Role>();
                u.Roles.Add(roleuser);
                ctx.Users.Add(u);
                ctx.SaveChanges();
                //userService.Add(user);
                //userService.Commit();


                return RedirectToAction("Index");
            }

            return View("User/Create", user);
        }

        // GET: Users/Edit/5
        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userService.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("User/Edit", user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "UserId,Username,Email,FirstName,LastName,IsActive,CreateDate")] User user)
        {
            if (ModelState.IsValid)
            {


                User usr = userService.GetById(user.UserId);
                usr.Username = user.Username;
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.Email = user.Email;
                usr.IsActive = user.IsActive;
                usr.CreateDate = user.CreateDate;
                userService.Update(usr);
                userService.Commit();

                return RedirectToAction("Index");
            }
            return View("User/Edit", user);
        }

        // GET: Users/Delete/5
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userService.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("User/Delete", user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedUser(int id)
        {
            User user = userService.GetById(id);
            userService.Delete(user);
            userService.Commit();
            return RedirectToAction("Index");
        }



        // GET: Roles/Details/5
        public ActionResult DetailsRole(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = ww.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View("Role/Details", role);
        }

        // GET: Roles/Create
        public ActionResult CreateRole()
        {
            return View("Role/Create");
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole([Bind(Include = "RoleId,RoleName,Description")] Role role)
        {
            if (ModelState.IsValid)
            {
                ww.Roles.Add(role);
                ww.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Role/Create", role);
        }

        // GET: Roles/Edit/5
        public ActionResult EditRole(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = ww.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View("Role/Edit", role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole([Bind(Include = "RoleId,RoleName,Description")] Role role)
        {
            if (ModelState.IsValid)
            {
                ww.Entry(role).State = EntityState.Modified;
                ww.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Role/Edit", role);
        }

        // GET: Roles/Delete/5
        public ActionResult DeleteRole(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = ww.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View("Role/Delete", role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = ww.Roles.Find(id);
            ww.Roles.Remove(role);
            ww.SaveChanges();
            return RedirectToAction("Index");
        }

        WebContext ww = new WebContext();

    }


}


