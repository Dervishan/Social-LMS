using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CoursePositionId { get; set; }
        public virtual CoursePosition CoursePosition { get; set; }
    }
}
