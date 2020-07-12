using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_LMS.Data;
using Social_LMS.Models;

namespace Social_LMS.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public EnrollmentsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrollment.Include(e => e.Course).Include(e => e.CoursePosition).Include(e => e.User);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: MyEnrollments
        public async Task<IActionResult> MyEnrollments()
        {
            var applicationDbContext = _context.Enrollment.Include(e => e.Course).Include(e => e.CoursePosition).Include(e => e.User).Where(e => e.UserId.ToString() == _userManager.GetUserId(User));
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.CoursePosition)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Code");
            ViewData["CourseName"] = new SelectList(_context.Course, "Id", "Name");
            ViewData["CoursePositionId"] = new SelectList(_context.CoursePosition, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name");
            return View();
        }
        // GET: Enrollments/Add
        public IActionResult Add()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Code");
            ViewData["CourseName"] = new SelectList(_context.Course, "Id", "Name");
            ViewData["CoursePositionId"] = new SelectList(_context.CoursePosition, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnrollmentDate,UserId,CourseId,CoursePositionId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Code", enrollment.CourseId);
            ViewData["CourseName"] = new SelectList(_context.Course, "Id", "Name", enrollment.Course.Name);
            ViewData["CoursePositionId"] = new SelectList(_context.CoursePosition, "Id", "Name", enrollment.CoursePositionId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", enrollment.UserId);
            return View(enrollment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,EnrollmentDate,UserId,CourseId,CoursePositionId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                enrollment.UserId = user.Id;
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyEnrollments));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Code", enrollment.CourseId);
            ViewData["CourseName"] = new SelectList(_context.Course, "Id", "Name", enrollment.Course.Name);
            ViewData["CoursePositionId"] = new SelectList(_context.CoursePosition, "Id", "Name", enrollment.CoursePositionId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", enrollment.UserId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Code", enrollment.CourseId);
            ViewData["CoursePositionId"] = new SelectList(_context.CoursePosition, "Id", "Name", enrollment.CoursePositionId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", enrollment.UserId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EnrollmentDate,UserId,CourseId,CoursePositionId")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Code", enrollment.CourseId);
            ViewData["CoursePositionId"] = new SelectList(_context.CoursePosition, "Id", "Name", enrollment.CoursePositionId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", enrollment.UserId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.CoursePosition)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
