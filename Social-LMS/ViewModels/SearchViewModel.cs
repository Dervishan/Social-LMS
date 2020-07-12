using Social_LMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Arama Metni")]
        public string SearchText { get; set; }

        [Display(Name = "Kullanıcı")]
        public bool SearchInUsers { get; set; }

        [Display(Name = "Ders")]
        public bool SearchInCourses { get; set; }

        [Display(Name = "Grup")]
        public bool SearchInGroups { get; set; }
        public List<User> UserResults { get; set; }
        public List<Course> CourseResults { get; set; }
        public List<Group> GroupResults { get; set; }
    }
}
