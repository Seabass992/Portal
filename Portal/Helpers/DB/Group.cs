using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Helpers.DB
{
    public class Group
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public virtual ICollection<Grouping> Groupings { get; set; }
    }
}