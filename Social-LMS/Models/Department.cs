using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class Department
    {
        public int Id {get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "Kısa departman adı 5 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Kısa departman adı")]
        public string NameShort { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Departman adı 40 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Departman adı")]
        public string NameFull { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Kuruluş tarihi")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Fakülte")]
        public int FacultyId { get; set; }
        [Display(Name = "Fakülte")]
        public Faculty Faculty { get; set; }
        [Display(Name = "Dersler")]
        public virtual List<Course> Courses { get; set; }
        [Display(Name = "İnsanlar")]
        public virtual List<User> People { get; set; }
    }
}
