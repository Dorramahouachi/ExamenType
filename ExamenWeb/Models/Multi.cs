using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class Multi
    {
        public List<Post> postdetails { get; set; }

        public int PostId { get; set; }
        public string Contenu { get; set; }
        public int vue { get; set; }
        public DateTime DatePost { get; set; }
        public int? UserId { get; set; }
        public List<ReactPost> reactdetails { get ;set;}
        public List<ReactPost> reactpostdetails { get; set; }
        public List<Post> postdetailsAll { get; set; }

    }
}