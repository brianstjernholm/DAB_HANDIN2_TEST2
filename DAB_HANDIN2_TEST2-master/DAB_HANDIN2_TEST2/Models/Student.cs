using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAB2.models
{
    public class Student
    {
        // DEFINE SELF
        //[Required]
        [Key]
        [Display(Name = "Student AuID")]
        public int StudentId { get; set; } //Key by annotation

        [Display(Name = "Student name")]
        public string Name { get; set; }

        // RELATIONS
        public List<Exercise> Exercises { get; set; }
        public List<Helprequest> StudentAssignments { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
