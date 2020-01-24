using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementSystem1.Models;

namespace ManagementSystem1.Controllers
{
    public class StudentCourseModelsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentCourseModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StudentCourseModels
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.StudentCourseModel.Include(s => s.Course).Include(s => s.Student);
            return View(await appDbContext.ToListAsync());
        }

        // GET: StudentCourseModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseModel = await _context.StudentCourseModel
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourseModel == null)
            {
                return NotFound();
            }

            return View(studentCourseModel);
        }

        // GET: StudentCourseModels/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Fname");
            return View();
        }

        // POST: StudentCourseModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,StudentId")] StudentCourseModel studentCourseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", studentCourseModel.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Fname", studentCourseModel.StudentId);
            return View(studentCourseModel);
        }

        // GET: StudentCourseModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseModel = await _context.StudentCourseModel.FindAsync(id);
            if (studentCourseModel == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", studentCourseModel.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Fname", studentCourseModel.StudentId);
            return View(studentCourseModel);
        }

        // POST: StudentCourseModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,StudentId")] StudentCourseModel studentCourseModel)
        {
            if (id != studentCourseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseModelExists(studentCourseModel.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title", studentCourseModel.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Fname", studentCourseModel.StudentId);
            return View(studentCourseModel);
        }

        // GET: StudentCourseModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseModel = await _context.StudentCourseModel
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourseModel == null)
            {
                return NotFound();
            }

            return View(studentCourseModel);
        }

        // POST: StudentCourseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourseModel = await _context.StudentCourseModel.FindAsync(id);
            _context.StudentCourseModel.Remove(studentCourseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseModelExists(int id)
        {
            return _context.StudentCourseModel.Any(e => e.Id == id);
        }
    }
}
