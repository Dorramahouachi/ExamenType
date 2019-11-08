using Domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public String Questions { get; set; }

        //public int? EntretienEnLigneId { get; set; }
        public virtual EntretienEnLigne EntretienEnLigne { get; set; }
        public ICollection<Choix> ListeChoix { get; set; }
        public ICollection<Reponse> ListeReponse { get; set; }


    }
}
