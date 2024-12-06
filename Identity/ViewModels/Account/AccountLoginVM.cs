using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModels.Account
{
    public class AccountLoginVM
    {
        [Required(ErrorMessage = "Must be entered!")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must be entered!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public  string  ReturnUrl { get; set; }
    }
}
