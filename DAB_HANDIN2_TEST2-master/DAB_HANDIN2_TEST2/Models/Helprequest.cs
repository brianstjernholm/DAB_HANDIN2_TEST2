using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAB2.models
{
    public class Helprequest
    {
        // DEFINE SELF
        [Key]
        [Display(Name = "Helprequest ID")]
        public int HelprequestId { get; set; } //Key
        public bool IsOpen { get; set; }

        // RELATIONS
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Display(Name = "Assignment ID")]
        public int AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
    }
}
