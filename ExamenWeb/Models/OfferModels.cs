using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class OfferModels
    {
        public int offerId { get; set; }
        public string titleOffer { get; set; }
        public string referenceOffer { get; set; }
        public string location { get; set; }
        public string durationOffer { get; set; }
        public float salary { get; set; }
        public string contractTypeOffer { get; set; }
        public int teamId { get; set; }
    }
}