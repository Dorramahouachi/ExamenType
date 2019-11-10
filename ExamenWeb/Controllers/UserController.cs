
using Domaine;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ExamenWeb.Security;

namespace ExamenWeb.Controllers
{

    [CustomAuthorize(Roles = "User")]
    [Authorize]
    public class UserController : BaseController
    {
       
        IUserService userService = new UserService();
        //
        // GET: /User/
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", null);
            
        }


    }
}