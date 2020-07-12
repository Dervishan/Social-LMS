using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_LMS.Models
{
    public class Group
    {
        public Group()
        {
            CreatedDate = DateTime.UtcNow.Date;
        }
        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "grup ismi minimum 4 maksimum 40 karakter olmalıdır", MinimumLength = 4)]
        [Display(Name = "isim")]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}")]
        [Display(Name = "oluşturma tarihi")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Kurucu")]
        public int UserId { get; set; }
        [Display(Name = "Kurucu")]
        public User User { get; set; }

        [Display(Name = "Gruptakiler")]
        public virtual List<UserGroup> People { get; set; }

        [Display(Name = "Mesajlar")]
        public virtual List<Message> MessagesReceived { get; set; }
    }
}