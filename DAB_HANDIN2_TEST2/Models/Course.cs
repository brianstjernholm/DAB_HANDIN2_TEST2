using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAB2.models
{
    public class Course
    {
        // DEFINE SELF
        //[Required]
        public int CourseId { get; set; } //Key by convention

        [Display(Name = "Course name")]
        public string Name { get; set; }

        // RELATIONS
        public List<Teacher> Teachers { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
