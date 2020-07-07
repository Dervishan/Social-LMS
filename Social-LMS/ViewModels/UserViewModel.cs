using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Social_LMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.ViewModels
{
    public class UserViewModel : IdentityUser<int>
    {
        [Required]
        [StringLength(20, ErrorMessage = "İsim 20 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Ad", Prompt = "Adınız")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Soyad 20 karakteri geçemez", MinimumLength = 2)]
        [Display(Name = "Soyad", Prompt = "Soyadınız")]
        public string Surname { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Doğum günü")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(300, ErrorMessage = "Hakkında 300 karakteri geçemez")]
        [Display(Name = "Hakkında", Description = "de bakalım birşeyler")]
        public string About { get; set; }

        [Display(Name = "Yıl")]
        public int YearId { get; set; }

        [Display(Name = "Yıl")]
        public Year Year { get; set; }

        [Display(Name = "Profil fotoğrafı")]
        public IFormFile Photo { get; set; }

        [Display(Name = "Hesap türü")]
        public int RoleId { get; set; }

        [Display(Name = "Hesap türü")]
        public Role Role { get; set; }
    }
}
