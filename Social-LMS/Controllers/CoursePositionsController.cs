using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_LMS.Data;
using Social_LMS.Models;

namespace Social_LMS.Controllers
{
    public class CoursePositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursePositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoursePositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoursePosition.ToListAsync());
        }

        // GET: CoursePositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursePosition = await _context.CoursePosition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursePosition == null)
            {
                return NotFound();
            }

            return View(coursePosition);
        }

        // GET: CoursePositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoursePositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CanEditCourse,CanGrade")] CoursePosition coursePosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursePosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coursePosition);
        }

        // GET: CoursePositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursePosition = await _context.CoursePosition.FindAsync(id);
            if (coursePosition == null)
            {
                return NotFound();
            }
            return View(coursePosition);
        }

        // POST: CoursePositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CanEditCourse,CanGrade")] CoursePosition coursePosition)
        {
            if (id != coursePosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursePosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursePositionExists(coursePosition.Id))
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
            return View(coursePosition);
        }

        // GET: CoursePositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursePosition = await _context.CoursePosition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursePosition == null)
            {
                return NotFound();
            }

            return View(coursePosition);
        }

        // POST: CoursePositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coursePosition = await _context.CoursePosition.FindAsync(id);
            _context.CoursePosition.Remove(coursePosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursePositionExists(int id)
        {
            return _context.CoursePosition.Any(e => e.Id == id);
        }
    }
}
