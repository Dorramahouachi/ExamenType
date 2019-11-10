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

        public int score { get; set;}
        //[ForeignKey("Offer")]
        //private int offerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime candidatureDate { get; set; }
       
        public enum etatCandidature
        {
            rejected = 1,
            accepted = 2,
            processing = 3,
            Quizz=4
           
        }
        public etatCandidature etat { get; set; }
    }
}
