using System.ComponentModel.DataAnnotations;

namespace MVCTest.ViewModels
{
    public class RegisterVM
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email is required")]
        public string email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="Passwords do not match")]
        public string confirmPassword { get; set; }

    }
}
