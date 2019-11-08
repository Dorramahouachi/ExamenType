using Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class QuestionController : Controller
    {
        private ExamenContext DbContext = new ExamenContext();
        // GET: Question
        public ActionResult Index()
        {
            ViewBag.Questions = DbContext.Questions.ToList();
            
            return View();
        }

        [HttpPost]
        public ActionResult GetResults(System.Web.Mvc.FormCollection formCollection)
        {
          
            int score = 0;
           

            foreach (string questionId in formCollection.Keys)
            {
                bool? iscorrect = false;


                 iscorrect = DbContext.Answers.Find(int.Parse
                    (formCollection[questionId])).Correct;


                if (iscorrect.Value)
                {
                    score++;
                }
            }
            ViewBag.score = score;
            return View("Result");
        }
    }
}