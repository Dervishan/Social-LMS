using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Social_LMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Social_LMS.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment hostEnvironment;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.hostEnvironment = hostEnvironment;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
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

            [Display(Name = "Profil fotoğrafı")]
            public IFormFile Photo { get; set; }

            [Phone]
            [Display(Name = "Telefon")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Fotoğrafı kaldır")]
            public bool IsPhotoToBeDeleted { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Name = user.Name,
                Surname = user.Surname,
                BirthDate = user.BirthDate,
                About = user.About,
                PhoneNumber = phoneNumber,
                IsPhotoToBeDeleted = false
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.Name != null)
            {
                user.Name = Input.Name;
            }
            if (Input.Surname != null)
            {
                user.Surname = Input.Surname;
            }
            if (Input.BirthDate != null)
            {
                user.BirthDate = Input.BirthDate;
            }
            if (Input.About != null)
            {
                user.About = Input.About;
            }
            if (Input.Photo != null)
            {
                if (Input.Photo.Length<= 2097152)
                {
                    if (user.Photo != null)
                    {
                        System.IO.File.Delete(Path.Combine(hostEnvironment.WebRootPath, "images", user.Photo));
                    }
                    string uniqueFileName = UploadedFile(Input);
                    user.Photo = uniqueFileName;
                }
                else
                {
                    StatusMessage = "Fotoğraf boyutu 2MB geçemez";
                    return RedirectToPage();
                }
            }
            if (Input.IsPhotoToBeDeleted == true)
            {
                System.IO.File.Delete(Path.Combine(hostEnvironment.WebRootPath, "images", user.Photo));
                user.Photo = null;
            }

            await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profiliniz güncellendi";
            return RedirectToPage();
        }

        private string UploadedFile(InputModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}