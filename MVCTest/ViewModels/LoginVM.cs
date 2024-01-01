using System.ComponentModel.DataAnnotations;

namespace MVCTest.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required!")]
        public string email { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
