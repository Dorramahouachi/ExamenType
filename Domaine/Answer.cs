using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domaine
{
   public class Answer
    {
        public int AnswerID { get; set; }
        public String Content { get; set; }
        public bool? Correct { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
        public int? QuestionID { get; set; }

        


    }
}
