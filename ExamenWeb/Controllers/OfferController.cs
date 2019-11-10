using Domaine;
using ExamenWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace ExamenWeb.Controllers
{
    public class OfferController : Controller
    {
        IServiceOffer os = new ServiceOffer();
        IServiceCandidature cs = new ServiceCandidature();
        // GET: Offer
        public ActionResult AllOffers()
        {
            IEnumerable<Offer> o ;
            o = os.GetAll();
            return View(o);
        }

        public ActionResult ApplyOffer(int idOffer, int idUser)
        {
            Candidature c = new Candidature();
            c.etat = "en cours";
            c.UserId = 9;
            c.OfferId = idOffer;
            cs.Add(c);
            cs.Commit();
            return RedirectToAction("AllOffers");
        }

        public ActionResult UnApplyOffer(int idOffer, int idUser)
        {
            IEnumerable<Candidature> c;
            c = cs.GetMany(i => i.OfferId == idOffer);
            foreach(var item in c)
            {
                if(item.UserId == idUser)
                {
                    cs.Delete(item);
                    cs.Commit();
                }
            }
            return RedirectToAction("AllOffers");
        }
    }
}
