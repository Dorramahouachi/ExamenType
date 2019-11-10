using Domaine;
using ExamenWeb.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class CandidatController : Controller
    {
        IServiceCandidat cs = new ServiceCandidat();
        IServiceCandidature cas = new ServiceCandidature();
        IServiceOffer co = new ServiceOffer();
        IServiceUser us = new ServiceUser();
        IServiceContacts cls = new ServiceContacts();
        public ActionResult CompleteProfil()
        {
            Candidat cm = new Candidat();
            cm = cs.Get(t => t.UserId == 9);
            CandidatModels c = new CandidatModels();
            c.UserId = cm.UserId;
            c.password = cm.password;
            c.name = cm.name;
            c.lastname = cm.lastname;
            c.Mail = cm.Mail;
            c.login = cm.login;
            c.phoneContact = cm.phoneContact;
            c.address = cm.address;
            c.birthDate = cm.birthDate;
            c.Country = cm.Country;
            c.Skills = cm.Skills;
            c.bio = cm.bio;
            c.picture = cm.picture;
            c.experience = cm.experience;
            c.actualPost = cm.actualPost;

            return View(c);
        }

        // POST: Candidat/Create/5
        [HttpPost]
        public ActionResult CompleteProfil(CandidatModels cm, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            {
                RedirectToAction("CompleteProfil");
            }
            else
            {
                Candidat c = new Candidat();
                c = cs.Get(t => t.UserId == 9);
                c.name = cm.name;
                c.lastname = cm.lastname;
                c.phoneContact = cm.phoneContact;
                c.address = cm.address;
                c.birthDate = cm.birthDate;
                c.Country = cm.Country;
                c.Skills = cm.Skills;
                c.bio = cm.bio;
                c.picture = file.FileName;
                c.experience = cm.experience;
                c.actualPost = cm.actualPost;
                cs.Update(c);
                cs.Commit();
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), fileName);
                    file.SaveAs(path);
                }
                TempData["Success"] = "Your Profil is Updated Successfully!";

            }
            return RedirectToAction("Profil");
        }

        public ActionResult Profil(HttpPostedFileBase file)
        {
            Candidat cm = new Candidat();
            CandidatModels c = new CandidatModels();
            cm = cs.Get(t => t.UserId == 9);
            c.UserId = cm.UserId;
            c.login = cm.login;
            c.Mail = cm.Mail;
            c.name = cm.name;
            c.lastname = cm.lastname;
            c.phoneContact = cm.phoneContact;
            c.address = cm.address;
            c.birthDate = cm.birthDate;
            c.Country = cm.Country;
            c.Skills = cm.Skills;
            c.bio = cm.bio;
            c.picture = cm.picture;
            c.experience = cm.experience;
            c.actualPost = cm.actualPost;
            c.password = cm.password;
            return View(c);
        }

        public ActionResult UpdateProfil(int id)
        {
            Candidat cm = new Candidat();
            cm = cs.Get(t => t.UserId == id);
            CandidatModels c = new CandidatModels();
            c.UserId = cm.UserId;
            c.password = cm.password;
            c.name = cm.name;
            c.lastname = cm.lastname;
            c.Mail = cm.Mail;
            c.login = cm.login;
            c.phoneContact = cm.phoneContact;
            c.address = cm.address;
            c.birthDate = cm.birthDate;
            c.Country = cm.Country;
            c.Skills = cm.Skills;
            c.bio = cm.bio;
            c.picture = cm.picture;
            c.experience = cm.experience;
            c.actualPost = cm.actualPost;
            return View(c);
        }

        // POST: Candidat/Create/5
        [HttpPost]
        public ActionResult UpdateProfil(CandidatModels cm, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            {
                RedirectToAction("UpdateProfil");
            }
            else
            {
                Candidat c = new Candidat();
                c = cs.Get(t => t.UserId == cm.UserId);
                c.name = cm.name;
                c.lastname = cm.lastname;
                c.phoneContact = cm.phoneContact;
                c.address = cm.address;
                c.birthDate = cm.birthDate;
                c.Country = cm.Country;
                c.Skills = cm.Skills;
                c.bio = cm.bio;
                c.picture = file.FileName;
                c.experience = cm.experience;
                c.actualPost = cm.actualPost;
                
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), fileName);
                    file.SaveAs(path);
                }
                c.picture = file.FileName;
                TempData["Success"] = "Your Profil is Updated Successfully!";

                cs.Update(c);
                cs.Commit();

            }
            return RedirectToAction("Profil");
        }

        public ActionResult ContactsCandidat(int id)
        {
            Candidat cm = new Candidat();
            cm = cs.Get(t => t.UserId == id);
            CandidatModels c = new CandidatModels();
            if(cm != null)
            {
                c.UserId = cm.UserId;
                c.password = cm.password;
                c.name = cm.name;
                c.lastname = cm.lastname;
                c.Mail = cm.Mail;
                c.login = cm.login;
                c.phoneContact = cm.phoneContact;
                c.address = cm.address;
                c.birthDate = cm.birthDate;
                c.Country = cm.Country;
                c.Skills = cm.Skills;
                c.bio = cm.bio;
                c.picture = cm.picture;
                c.experience = cm.experience;
                c.actualPost = cm.actualPost;
            }
            return View(c);
        }
        
        public ActionResult VisiteProfil(int id)
        {
            Candidat cm = new Candidat();
            cm = cs.Get(t => t.UserId == id);
            CandidatModels c = new CandidatModels();
            c.UserId = cm.UserId;
            c.password = cm.password;
            c.name = cm.name;
            c.lastname = cm.lastname;
            c.Mail = cm.Mail;
            c.login = cm.login;
            c.phoneContact = cm.phoneContact;
            c.address = cm.address;
            c.birthDate = cm.birthDate;
            c.Country = cm.Country;
            c.Skills = cm.Skills;
            c.bio = cm.bio;
            c.picture = cm.picture;
            c.experience = cm.experience;
            c.actualPost = cm.actualPost;
            return View(c);
        }
        
        public ActionResult DeleteContact(int id)
        {
            Contacts c = new Contacts();
            c = cls.Get(t => t.ContactId == id);
            cls.Delete(c);
            cls.Commit();
            return RedirectToAction("ContactsCandidat", new { id = 9 });
        }
        public ActionResult Applyings(int id)
        {
            Offer o = new Offer();
            List<Offer> ol = new List<Offer>();
            IEnumerable<Candidature> c;
            c = cas.GetMany(t => t.UserId == id);
            foreach(var item in c)
            {
                o = co.Get(t => t.offerId == item.OfferId);
                ol.Add(o);
            }
            return View(ol);
        }

        public ActionResult DeleteCandidature(int id)
        {
            Candidature c = new Candidature();
            c = cas.Get(t => t.OfferId == id);
            cas.Delete(c);
            cas.Commit();
            return RedirectToAction("Applyings", new { id = 9 });
        }
    }
}
