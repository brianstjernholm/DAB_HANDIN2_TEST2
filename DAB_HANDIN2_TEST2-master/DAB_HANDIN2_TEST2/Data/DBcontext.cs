using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB2.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAB2.data
{
    public class DBcontext : DbContext
    {
  
        public DBcontext(DbContextOptions<DBcontext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Helprequest> Helprequests { get; set; }


        #region loggerfactory

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Default");

        //    var logs = new List<String>();
        //    var loggerFactory = context.GetService<ILoggerFactory>();
        //    loggerFactory.AddProvider(new MyLoggerProvider(logs, LogLevel.Information));
        //}

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Defining composite key
            modelBuilder.Entity<Exercise>().HasKey(em => new { em.Number, em.Lecture });

            //// Defining composite key (SHADOW TABLE: HELPREQUEST)
            //modelBuilder.Entity<Helprequest>().HasKey(sam => new { sam.AssignmentId, sam.StudentId });

            //// Defining composite key (SHADOW TABLE: STUDENTCOURSEMODEL)
            //modelBuilder.Entity<StudentCourse>().HasKey(scm => new { scm.CourseId, scm.StudentId });
        }
    }
}
