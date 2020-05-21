using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Ders adı 10 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Ders adı")]
        public string Name { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Ders kodu 4 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Ders kodu")]
        public string Code { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Açıklama 200 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Oluşturma tarihi")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Departman")]
        public int DepartmentId { get; set; }
        [Display(Name = "Departman")]
        public Department Department { get; set; }
        [Display(Name = "Sınıf")]
        public virtual List<Enrollment> People { get; set; }
    }
}
