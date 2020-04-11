using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAB2.models
{
    public class Teacher
    {
        // DEFINE SELF
        //[Required]
        [Key]
        [Display(Name = "AuId")]
        public int TeacherId { get; set; } //Key by annotation

        [Display(Name = "Teacher name")]
        public string Name { get; set; }

        // RELATIONS
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public List<Exercise> Exercises { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
