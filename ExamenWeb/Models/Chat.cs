using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class Chat
    {


       
        public int ChatId { get; set; }

       
       
        public int? SendId { get; set; }

        
        public int? RecieveId { get; set; }

       
        public string Contenu { get; set; }

       
        public int Vue { get; set; }

        
        public DateTime DateSend { get; set; }



    }
}