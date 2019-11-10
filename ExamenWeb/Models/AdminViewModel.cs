using Domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class AdminViewModel
    {

        [Key]
        public List<User> Users { get; set; }


        public List<Role> Roles { get; set; }

    }


}