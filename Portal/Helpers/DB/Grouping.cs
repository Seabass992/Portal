using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Helpers.DB
{
    public class Grouping
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Link")]
        public int LinkId { get; set; }

        [ForeignKey("LinkId")]
        public Link Link { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}