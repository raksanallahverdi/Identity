using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModels.Account
{
    public class AccountForgetPasswordVM
    {
        [Required(ErrorMessage ="Mail Must be Entered!")]
        public string Email { get; set; }
    }
}
