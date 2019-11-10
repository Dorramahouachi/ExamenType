using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domaine;

namespace ExamenWeb.Models
{
    public class Multiple
    { 
        public List<Post> postdetails { get; set; }



        public List<Comment> commentdetails { get; set; }

    

        public int CommentId { get; set; }
        public string Contenu { get; set; }
        public DateTime DateComment { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }




       




        

    }
}