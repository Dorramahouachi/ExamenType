using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class ContactModels
    {
        public int ContactId { get; set; }
        public virtual UserModels Users { get; set; }
        public int? UserId { get; set; }
        public String contactId1 { get; set; }
        public DateTime contactDate { get; set; }
        public String Name { get; set; }
        public String lastName { get; set; }
        public String actualPost { get; set; }
        public String pic { get; set; }

    }
}