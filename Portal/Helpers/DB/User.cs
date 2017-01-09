using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Helpers.DB
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<UsersRoles> UserRoles { private get; set; }

        public virtual List<string> Roles
        {
            get { return UserRoles.Select(r => r.Role.Name).ToList(); }
        }
    }
}