using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAB2.models
{
    public class Exercise
    {
        // DEFINE SELF
        //[Key]
        public string Lecture { get; set; } //Key by fluent; defined in context
        //[Key]
        public int Number { get; set; }     //Key by fluent; defined in context
        public string HelpWhere { get; set; }

        // RELATIONS
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
