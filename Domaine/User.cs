using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

    }
}
