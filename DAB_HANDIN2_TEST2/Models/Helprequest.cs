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
        public int HelprequestId { get; set; } //Key

        // RELATIONS
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
    }
}
