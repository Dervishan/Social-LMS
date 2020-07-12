using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_LMS.Models
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            RoleId = 2;
            RegisterDate = DateTime.UtcNow.Date;
            IsDeleted = false;
            Year = Year.Freshman;
        }

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

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Kayıt Tarihi")]
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        [StringLength(300, ErrorMessage = "Hakkında 300 karakteri geçemez")]
        [Display(Name = "Hakkında", Description = "de bakalım birşeyler")]
        public string About { get; set; }

        public bool IsDeleted { get; set; }

        [Display(Name = "Yıl")]
        public Year Year { get; set; }

        [Display(Name = "Profil fotoğrafı")]
        public string Photo { get; set; }

        [Display(Name = "Hesap türü")]
        public int RoleId { get; set; }

        [Display(Name = "Hesap türü")]
        public Role Role { get; set; }

        [Display(Name = "Dersler")]
        public virtual List<Enrollment> Enrollments { get; set; }

        [Display(Name = "Gruplar")]
        public virtual List<UserGroup> UserGroups { get; set; }
        [InverseProperty("Sender")]
        public virtual List<Message> MessagesSent { get; set; }

        [InverseProperty("Recipient")]
        public virtual List<Message> MessagesReceived { get; set; }

        [Display(Name = "Bağlantılar")]
        public virtual List<User> Contacts { get; set; }
    }
}