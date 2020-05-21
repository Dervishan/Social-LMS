using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Fakülte adı 40 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Fakülte adı")]
        public string Name { get; set; }    
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Kuruluş tarihi")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Departmanlar")]
        public virtual List<Department> Departments { get; set; }
    }
}
