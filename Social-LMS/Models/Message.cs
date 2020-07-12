using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_LMS.Models
{
    public class Message
    {
        public Message()
        {
            CreatedTime = DateTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(400, ErrorMessage = "Grup ismi minimum 1 maksimum 400 karakter olmalıdır", MinimumLength = 1)]
        [Display(Name = "Mesaj")]
        public string Text { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Oluşturma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime CreatedTime { get; set; }

        public bool IsDeleted { get; set; }

        [Display(Name = "Gönderen")]
        public int SenderUserId { get; set; }

        [Display(Name = "Gönderen")]
        public User Sender { get; set; }

        [Display(Name = "Alıcı")]
        public int? RecipientUserId { get; set; }

        [Display(Name = "Alıcı")]
        public User Recipient { get; set; }

        [Display(Name = "Alıcı")]
        public int? GroupId { get; set; }

        [Display(Name = "Alıcı")]
        public Group Group { get; set; }
    }
}