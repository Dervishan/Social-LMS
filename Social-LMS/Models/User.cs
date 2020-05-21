using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            RoleId = 1;
            RegisterDate = DateTime.UtcNow;
        }
        [Required]
        [StringLength(20, ErrorMessage = "İsim 20 karakteri geçemez", MinimumLength = 2)]
        [Display(Name ="İsim")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Soyad 20 karakteri geçemez", MinimumLength = 2)]
        [Display(Name ="Soyad",Prompt ="Soyadınızı girin")]
        public string Surname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Doğum günü")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy}")]
        [Display(Name ="Kayıt Tarihi")]
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }
        [StringLength(300, ErrorMessage = "Hakkında 300 karakteri geçemez")]
        [Display(Name ="Hakkında",Description ="de bakalım bişeyler")]
        public string? About { get; set; }
        [Display(Name = "Yıl")]
        public int YearId { get; set; }
        [Display(Name = "Yıl")]
        public Year Year { get; set; }
        [Display(Name = "Hesap türü")]
        public int RoleId { get; set; }
        [Display(Name = "Hesap türü")]
        public Role Role { get; set; }
        [Display(Name = "Dersler")]
        public virtual List<Enrollment> Enrollments { get; set; }
        [Display(Name = "Bağlantılar")]
        public virtual List<User> Contacts { get; set; }
    }
}
