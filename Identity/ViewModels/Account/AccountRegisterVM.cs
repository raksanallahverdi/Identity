using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModels.Account
{
    public class AccountRegisterVM
    {
        [Required(ErrorMessage = "Must be entered!")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Must be entered!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Must be entered!")]
        public  string  City { get; set; }
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Must be entered!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Must be entered!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Passwords didn't match")]
        public string ConfirmPassword { get; set; }
    }
}
