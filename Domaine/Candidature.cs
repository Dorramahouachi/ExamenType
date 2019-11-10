using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Candidature
    {
        [Key]
        public int candidatureId { get; set; }
        public virtual User Users { get; set; }
        public int? UserId { get; set; }

        public virtual Offer Offers { get; set; }
        public int? OfferId { get; set; }
        /*[DataType(DataType.Date)]
        public DateTime candidatureDate { get; set; }*/
        
        public String etat { get; set; }
        
    }
}
