using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAB2.models
{
    public class StudentCourse
    {
        // DEFINE SELF
        public int StudentCourseId { get; set; } //Key by convention
        public string Semester { get; set; }
        public bool Active { get; set; }

        // RELATIONS
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
