using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Kayıt tarihi")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CoursePositionId { get; set; }
        public virtual CoursePosition CoursePosition { get; set; }
    }
}
