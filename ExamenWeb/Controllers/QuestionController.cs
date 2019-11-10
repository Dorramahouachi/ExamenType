using Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Domaine;

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
        public ActionResult IndexC()
        {
            return RedirectToAction("CandidatCandidatures", "Candidatures");

        }
        [HttpPost]
        public ActionResult GetResults(int? id,System.Web.Mvc.FormCollection formCollection, [Bind(Include = "score,etat")] Candidature candidature)
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
            candidature = DbContext.Candidature.Find(1);
            candidature.score = score;
            if(score > 0)
            {
                candidature.etat = Candidature.etatCandidature.accepted;
            }
           
            DbContext.SaveChanges();

           
            return View("Result");
        }
    }
}