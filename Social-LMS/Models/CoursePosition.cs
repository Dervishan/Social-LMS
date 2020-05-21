using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class CoursePosition
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Pozisyon adı 40 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Pozisyon adı")]
        public string Name { get; set; }
        [Required]
        public bool CanEditCourse { get; set; }
        [Required]
        public bool CanGrade { get; set; }
    }
}
