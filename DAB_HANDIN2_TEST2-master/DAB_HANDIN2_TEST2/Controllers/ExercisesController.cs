﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAB2.data;
using DAB2.models;

namespace DAB_HANDIN2_TEST2.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly DBcontext _context;

        public ExercisesController(DBcontext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index(string searchString) //har ændret navne på variablerne så de stemmer lidt bedre overens med de anvendte klasser
        {
            //var users = from u in _context.User select u;
            var exercises = from e in _context.Exercises select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                exercises = exercises.Where(e => e.Teacher.Name.Contains(searchString)).Include(e => e.Course).Include(e => e.Student).Include(e => e.Teacher);
                //users = users.Include(e => e.Course).Include(e => e.Student).Include(e => e.Teacher);
            }
            

            exercises = exercises.Include(e => e.Course).Include(e => e.Student).Include(e => e.Teacher);

            return View(await exercises.ToListAsync());
        }



        // Gamle index af exercise
        //public async Task<IActionResult> Index()
        //{
        //    var dBcontext = _context.Exercises.Include(e => e.Course).Include(e => e.Student).Include(e => e.Teacher);
        //    return View(await dBcontext.ToListAsync());
        //}



        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises
                .Include(e => e.Course)
                .Include(e => e.Student)
                .Include(e => e.Teacher)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lecture,Number,HelpWhere,TeacherId,StudentId,CourseId")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", exercise.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exercise.StudentId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", exercise.TeacherId);
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", exercise.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exercise.StudentId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", exercise.TeacherId);
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lecture,Number,HelpWhere,TeacherId,StudentId,CourseId")] Exercise exercise)
        {
            if (id != exercise.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseExists(exercise.Number))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", exercise.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exercise.StudentId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", exercise.TeacherId);
            return View(exercise);
        }

        //GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises
                .Include(e => e.Course)
                .Include(e => e.Student)
                .Include(e => e.Teacher)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        public async Task<IActionResult> query(int? teacherId, int? courseId)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var query3 = _context.Exercises.Where(e => e.CourseId == courseId).Where(e => e.TeacherId == teacherId).Select(x => x.HelpWhere).ToList();
            //ViewData["list"] = query3;


            var query3 = _context.Exercises.Where(e => e.CourseId == courseId).Where(e => e.TeacherId == teacherId).ToList();

            //if (exercise == null)
            //{
            //    return NotFound();
            //}

            return View(query3);
        }


        //public async Task<IActionResult> query(string teacherName, int courseId)
        public async Task<IActionResult> query(string teacherName, int courseId)
        {
            //var exercise = _context.Exercises.Where(e => e.TeacherId == teacherId).ToList();
            //var exercises = _context.Exercises.Where(s => s.HelpWhere).FirstOrDefault();
            //var student = _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            ////var helprequests = _context.Helprequests.Where(h => h.Student.Name == student.Name).ToList();

            var exercises = _context.Exercises
                .Where(e => e.Teacher.Name == teacherName)
                .Where(e => e.CourseId == courseId)
                //.Include(e => e.Student.Name)
                .Include(e => e.Student)
                .ToList();
            var students = _context.Students.ToList();



            //ViewBag.Students = new Student[]{};
            //ViewBag.Students = students;
            //ViewData["students"]= students.Name.ToString();

            //ViewData["CourseName"] = _context.Courses.Where(c => c.CourseId == courseId).Include(c => c.Name);
            //ViewData["name"] = student.Name.ToString();
            return View(exercises);

        }


        // GET: helpwhere
        public IActionResult GetExerciseHelpWhere()
        {
            ViewData["Name"] = new SelectList(_context.Teachers, "Name", "Name");
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetExerciseHelpWhere([BindAttribute("Name,CourseId")] Teacher teacher, Course course, Student student)
        {
            ViewData["Name"] = new SelectList(_context.Teachers, "Name", "Name", teacher.Name);
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", course.CourseId);

            //var teacherQueried = _context.Teachers.Where(t => t.Name == ViewData["Name"]);
            //var coursesQueried = _context.Courses.Where(c => c.CourseId.ToString() == ViewData["CourseId"]);

            var exercise = _context.Exercises.Where(e => e.Teacher.Name == teacher.Name).Where(e => e.CourseId == course.CourseId).Include(e => e.Student);

            return View("query", exercise);
        }




        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.Number == id);
        }
    }
}
