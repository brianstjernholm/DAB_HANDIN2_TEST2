using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAB2.data;
using DAB2.models;

namespace DAB_HANDIN2_TEST2.Controllers
{
    public class HelprequestsController : Controller
    {
        private readonly DBcontext _context;

        public HelprequestsController(DBcontext context)
        {
            _context = context;
        }

        // GET: Helprequests
        public async Task<IActionResult> Index()
        {
            var dBcontext = _context.Helprequests.Include(h => h.Assignment).Include(h => h.Student);
            return View(await dBcontext.ToListAsync());
        }

        // GET: Helprequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helprequest = await _context.Helprequests
                .Include(h => h.Assignment)
                .Include(h => h.Student)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (helprequest == null)
            {
                return NotFound();
            }

            return View(helprequest);
        }

        // GET: Helprequests/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: Helprequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,AssignmentId")] Helprequest helprequest) //HelprequestId, // klippet som første param
        {
            var student = _context.Students.Where(s => s.StudentId == helprequest.StudentId).FirstOrDefault();
            var assignment = _context.Assignments.Where(a => a.AssignmentId == helprequest.AssignmentId)
                .FirstOrDefault();

            var request = new Helprequest()
            {
                Student = student,
                Assignment = assignment
            };

            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", helprequest.AssignmentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", helprequest.StudentId);
            return View(helprequest);
        }

        // GET: Helprequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var helprequest = await _context.Helprequests.FindAsync(id);
            var helprequest = _context.Helprequests.Where(h => h.HelprequestId == id).FirstOrDefault();
            if (helprequest == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", helprequest.AssignmentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", helprequest.StudentId);
            return View(helprequest);
        }

        // POST: Helprequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HelprequestId,StudentId,AssignmentId")] Helprequest helprequest)
        {
            if (id != helprequest.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helprequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelprequestExists(helprequest.AssignmentId))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", helprequest.AssignmentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", helprequest.StudentId);
            return View(helprequest);
        }

        // GET: Helprequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helprequest = await _context.Helprequests
                .Include(h => h.Assignment)
                .Include(h => h.Student)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (helprequest == null)
            {
                return NotFound();
            }

            return View(helprequest);
        }

        // POST: Helprequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helprequest = await _context.Helprequests.FindAsync(id);
            _context.Helprequests.Remove(helprequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelprequestExists(int id)
        {
            return _context.Helprequests.Any(e => e.AssignmentId == id);
        }


        // GET: find request by student name
        //public async Task<IActionResult> FindRequests(string name)
        //{
        //    if (name == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = _context.Students.Where(s => s.Name == name).FirstOrDefault();

        //    var helprequests = _context.Helprequests.Where(h => h.Student.Name == student.Name).ToList();

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId");
        //    ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
        //    return View();
            //return View(helprequests);
        //}
    }
}
