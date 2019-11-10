using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class CandidatureModels
    {
        public int candidatureId { get; set; }
        public virtual UserModels Users { get; set; }
        public int? UserId { get; set; }

        public virtual OfferModels Offers { get; set; }
        public int? OfferId { get; set; }

        public String etat { get; set; }
    }
}