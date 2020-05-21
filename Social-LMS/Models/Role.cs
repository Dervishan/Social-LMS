using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_LMS.Models
{
    public class Role : IdentityRole<int>
    {
        [Display(Name = "Kullanıcılar")]
        public virtual List<User> Users { get; set; }
        [Display(Name = "Yetki türü")]
        public int AuthorizationId { get; set; }
        [Display(Name = "Yetki türü")]
        public Authorization Authorization { get; set; }
    }
}
