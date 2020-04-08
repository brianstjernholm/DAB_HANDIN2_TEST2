using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB2.data;
using DAB2.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAB2.data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBcontext(serviceProvider.GetRequiredService<DbContextOptions<DBcontext>>())) //serviceProvider.GetRequiredService<DbContextOptions<DbContext>>())
            {
                if (context.Students.Any())
                {
                    System.Console.WriteLine("data already exists - not seeding");
                    return;
                }


                #region students

                //creating students
                Student student1 = new Student()
                {
                    Name = "Victor Kildahl"
                };
                context.Students.Add(student1);

                Student student2 = new Student
                {
                    Name = "Lasse Mossel"
                };
                context.Students.Add(student2);

                Student student3 = new Student()
                {
                    Name = "Marc Warming"
                };
                context.Students.Add(student3);

                Student student4 = new Student()
                {
                    Name = "Brian Stjernholm"
                };
                context.Students.Add(student4);

                #endregion


                #region courses

                // creating courses
                Course DAB = new Course()
                {
                    Name = "DAB"
                };

                Course GUI = new Course()
                {
                    Name = "GUI"
                };

                Course SWD = new Course()
                {
                    Name = "SWD"
                };

                Course SWT = new Course()
                {
                    Name = "SWT"
                };

                Course NGK = new Course()
                {
                    Name = "NGK"
                };

                context.Courses.Add(DAB);
                context.Courses.Add(GUI);
                context.Courses.Add(SWD);
                context.Courses.Add(SWT);
                context.Courses.Add(NGK);

                #endregion


                #region studentcourses

                // Creating studentcourses

                StudentCourse sc1 = new StudentCourse()
                {
                    Semester = "Semester 1",
                    Active = true,
                    Course = DAB,
                    Student = student1
                };
                context.StudentCourses.Add(sc1);

                StudentCourse sc2 = new StudentCourse()
                {
                    Semester = "Semester 2",
                    Active = true,
                    Course = DAB,
                    Student = student2
                };
                context.StudentCourses.Add(sc2);

                StudentCourse sc3 = new StudentCourse()
                {
                    Semester = "Semester 2",
                    Active = true,
                    Course = GUI,
                    Student = student3
                };
                context.StudentCourses.Add(sc3);

                StudentCourse sc4 = new StudentCourse()
                {
                    Semester = "Semester 4",
                    Active = true,
                    Course = GUI,
                    Student = student1
                };
                context.StudentCourses.Add(sc4);

                #endregion


                #region teachers

                // creating teachers
                Teacher teacher1 = new Teacher()
                {
                    Name = "Henrik Kirk",
                    Course = DAB
                };

                Teacher teacher2 = new Teacher()
                {
                    Name = "Poul Rovsing",
                    Course = GUI
                };

                Teacher teacher3 = new Teacher()
                {
                    Name = "Michael Loft",
                    Course = NGK
                };

                Teacher teacher4 = new Teacher()
                {
                    Name = "Frank Bodholdt",
                    Course = SWT
                };

                Teacher teacher5 = new Teacher()
                {
                    Name = "Michael Alrøe",
                    Course = SWD
                };

                context.Teachers.Add(teacher1);
                context.Teachers.Add(teacher2);
                context.Teachers.Add(teacher3);
                context.Teachers.Add(teacher4);
                context.Teachers.Add(teacher5);

                #endregion


                #region assignments

                // Creating assignments
                Assignment assignment1 = new Assignment()
                {
                    Course = DAB,
                    Teacher = teacher1
                };

                Assignment assignment2 = new Assignment()
                {
                    Course = DAB,
                    Teacher = teacher1
                };

                Assignment assignment3 = new Assignment()
                {
                    Course = SWT,
                    Teacher = teacher4
                };

                Assignment assignment4 = new Assignment()
                {
                    Course = SWD,
                    Teacher = teacher3
                };

                Assignment assignment5 = new Assignment()
                {
                    Course = NGK,
                    Teacher = teacher5
                };

                context.Assignments.Add(assignment1);
                context.Assignments.Add(assignment2);
                context.Assignments.Add(assignment3);
                context.Assignments.Add(assignment4);
                context.Assignments.Add(assignment5);

                #endregion


                #region exercises

                //////Creating exercises
                //Exercise ex1 = new Exercise()
                //{
                //    Lecture = "L1",
                //    Number = 1,
                //    HelpWhere = "Nygaard kælderen",
                //    Student = student1,
                //    Teacher = teacher1,
                //    Course = DAB
                //};

                //Exercise ex2 = new Exercise()
                //{
                //    Lecture = "L1",
                //    Number = 2,
                //    HelpWhere = "Nygaard kælderen",
                //    Student = student2,
                //    Course = NGK,
                //    Teacher = teacher5
                //};

                //Exercise ex3 = new Exercise()
                //{
                //    Lecture = "L1",
                //    Number = 1,
                //    HelpWhere = "Nygaard kælderen",
                //    Student = student3,
                //    Course = SWD,
                //    Teacher = teacher3
                //};

                //Exercise ex4 = new Exercise()
                //{
                //    Lecture = "L1",
                //    Number = 1,
                //    HelpWhere = "Nygaard kælderen",
                //    Student = student3,
                //    Course = SWT,
                //    Teacher = teacher4
                //};

                //Exercise ex5 = new Exercise()
                //{
                //    Lecture = "2",
                //    Number = 1,
                //    HelpWhere = "Nygaard kælderen",
                //    Course = DAB,
                //    Teacher = teacher1,
                //    Student = student4
                //};

                //Exercise ex6 = new Exercise()
                //{
                //    Lecture = "1",
                //    Number = 1,
                //    HelpWhere = "Nygaard kælderen",
                //    Course = GUI,
                //    Teacher = teacher2,
                //    Student = student4
                //};

                //context.Exercises.Add(ex1);
                //context.Exercises.Add(ex2);
                //context.Exercises.Add(ex3);
                //context.Exercises.Add(ex4);
                //context.Exercises.Add(ex5);
                //context.Exercises.Add(ex6);

                #endregion

                //// creating helprequest
                //Helprequest helprequest1 = new Helprequest()
                //{
                //    Student = student1,
                //    Assignment = assignment1
                //};
                //context.Helprequests.Add(helprequest1);

                context.SaveChanges();
                System.Console.WriteLine("Data saved");
            }
        }
    }
}
