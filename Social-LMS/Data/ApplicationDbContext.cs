using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social_LMS.Models;

namespace Social_LMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Social_LMS.Models.Year> Year { get; set; }
        public DbSet<Social_LMS.Models.Faculty> Faculty { get; set; }
        public DbSet<Social_LMS.Models.Department> Department { get; set; }
        public DbSet<Social_LMS.Models.Role> Role { get; set; }
        public DbSet<Social_LMS.Models.Authorization> Authorization { get; set; }
        public DbSet<Social_LMS.Models.Course> Course { get; set; }
        public DbSet<Social_LMS.Models.User> User { get; set; }
    }
}
