using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModels.Account
{
    public class AccountResetPasswordVM
    {
       
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }  
        [Required(ErrorMessage = "Must be entered!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Must be entered!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords didn't match")]
        public string ConfirmPassword { get; set; }
       
        public string Token { get; set; }
    }
}
