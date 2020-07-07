using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Social_LMS.Models
{
    public class Role : IdentityRole<int>
    {
        [Display(Name = "Kullanıcılar")]
        public virtual List<User> Users { get; set; }
    }
}