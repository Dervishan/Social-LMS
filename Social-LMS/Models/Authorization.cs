using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class Authorization 
    {
        public int Id { get; set; }
        [Display(Name = "Ders oluşturma yetkisi")]
        public bool ClassCreate { get; set; }
        [Display(Name = "Ders silme yetkisi")]
        public bool ClassDelete { get; set; }
        [Display(Name = "Ders düzenleme yetkisi")]
        public bool ClassEdit { get; set; }
    }
}
