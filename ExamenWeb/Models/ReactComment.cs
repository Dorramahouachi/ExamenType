using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class ReactComment
    {
       

        public int ReactCommentId { get; set; }


        
        public int? UserId { get; set; }


        public string TypeReact { get; set; }


       
        public int? CommentId { get; set; }

    }
}