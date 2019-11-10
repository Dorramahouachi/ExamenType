using Data;
using Domaine;
using Service;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

using System.Web.Mvc;
using ExamenWeb.Models;
using ExamenWeb.DAL;
using ExamenWeb.Controllers;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {

        public static string msg;
        public ActionResult Index()
        {
            if (msg != null)
            {
                if (msg.Equals("login-e"))
                {
                    ViewBag.error = "Incorrect username and / or password";
                }

                if (msg.Equals("regiter-s"))
                {
                    ViewBag.success = "Login now to active your account";
                }
                if (msg.Equals("res-e"))
                {
                    ViewBag.error = "login please";
                }
                if (msg.Equals("place-e"))
                {
                    ViewBag.error = "pas de place sorry";
                }
                msg = null;
            }
            return View();
        }

    public ActionResult candidatV()
    {

        return View("CandidatV");
    }
    public ActionResult Log()
        {
            return View("Log");
        }
    public ActionResult Sign()
        {
            return View("Sign");
        }
    }


}