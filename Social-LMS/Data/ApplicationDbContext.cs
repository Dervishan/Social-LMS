using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social_LMS.Models;
using Social_LMS.ViewModels;

namespace Social_LMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Social_LMS.Models.Faculty> Faculty { get; set; }
        public DbSet<Social_LMS.Models.Department> Department { get; set; }
        public DbSet<Social_LMS.Models.Role> Role { get; set; }
        public DbSet<Social_LMS.Models.Course> Course { get; set; }
        public DbSet<Social_LMS.Models.User> User { get; set; }
        public DbSet<Social_LMS.Models.Group> Group { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Social_LMS.Models.Message> Message { get; set; }

        public DbSet<Social_LMS.Models.CoursePosition> CoursePosition { get; set; }

        public DbSet<Social_LMS.Models.Enrollment> Enrollment { get; set; }


    }
}