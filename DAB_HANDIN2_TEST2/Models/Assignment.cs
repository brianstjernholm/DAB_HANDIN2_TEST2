using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAB2.models
{
    public class Assignment
    {
        // DEFINE SELF
        [Key]
        public int AssignmentId { get; set; }   //Key

        // RELATIONS
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public virtual List<Helprequest> StudentAssignments { get; set; }
    }

}
