using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Social_LMS.Data;
using Social_LMS.Models;
using Social_LMS.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel searchModel)
        {
            IQueryable<User> users = null;
            IQueryable<Course> courses = null;
            IQueryable<Group> groups = null;
            if (!String.IsNullOrWhiteSpace(searchModel.SearchText))
            {
                if (searchModel.SearchInUsers)
                {
                    users = _context.Users.AsQueryable().Include(e => e.Enrollments).ThenInclude(c => c.Course);
                    users = users.Where(u => u.Name.Contains(searchModel.SearchText) || u.Surname.Contains(searchModel.SearchText) || u.PhoneNumber.Contains(searchModel.SearchText)
                                          || u.Email.Contains(searchModel.SearchText) || u.About.Contains(searchModel.SearchText));
                    searchModel.UserResults = await users.ToListAsync();
                    foreach (var item in searchModel.UserResults)
                    {
                        searchModel.UserResults = searchModel.UserResults.Where(v => v.IsDeleted == false).ToList();
                    }
                }
                if (searchModel.SearchInCourses)
                {
                    courses = _context.Course.AsQueryable().Include(d => d.Department);
                    courses = courses.Where(u => u.Name.Contains(searchModel.SearchText) || u.Code.Contains(searchModel.SearchText) || u.Description.Contains(searchModel.SearchText)
                                          || u.Department.NameShort.Contains(searchModel.SearchText));
                    searchModel.CourseResults = await courses.ToListAsync();
                    foreach (var item in searchModel.CourseResults)
                    {
                        searchModel.CourseResults = searchModel.CourseResults.Where(v => v.IsVisible == true).ToList();
                    }
                }
                if (searchModel.SearchInGroups)
                {
                    groups = _context.Group.AsQueryable();
                    groups = groups.Where(u => u.Name.Contains(searchModel.SearchText));
                    searchModel.GroupResults = await groups.ToListAsync();
                }
                if (!searchModel.SearchInUsers && !searchModel.SearchInCourses && !searchModel.SearchInGroups)
                {
                    users = _context.Users.AsQueryable().Include(e => e.Enrollments).ThenInclude(c => c.Course);
                    users = users.Where(u => u.Name.Contains(searchModel.SearchText) || u.Surname.Contains(searchModel.SearchText) || u.PhoneNumber.Contains(searchModel.SearchText)
                                          || u.Email.Contains(searchModel.SearchText) || u.About.Contains(searchModel.SearchText));
                    searchModel.UserResults = await users.ToListAsync();
                    foreach (var item in searchModel.UserResults)
                    {
                        searchModel.UserResults = searchModel.UserResults.Where(v => v.IsDeleted == false).ToList();
                    }
                    courses = _context.Course.AsQueryable().Include(d => d.Department);
                    courses = courses.Where(c => c.Name.Contains(searchModel.SearchText) || c.Code.Contains(searchModel.SearchText) || c.Description.Contains(searchModel.SearchText)
                                          || c.Department.NameShort.Contains(searchModel.SearchText));
                    searchModel.CourseResults = await courses.ToListAsync();
                    foreach (var item in searchModel.CourseResults)
                    {
                        searchModel.CourseResults = searchModel.CourseResults.Where(v => v.IsVisible == true).ToList();
                    }
                    groups = _context.Group.AsQueryable();
                    groups = groups.Where(g => g.Name.Contains(searchModel.SearchText));
                    searchModel.GroupResults = await groups.ToListAsync();
                }
            }
            else
            {
                return View();
            }
            return View(searchModel);
        }
    }
}