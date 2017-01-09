using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Helpers.DB
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public bool InModal { get; set; }

        public virtual ICollection<Grouping> Groupings { get; set; }
    }
}