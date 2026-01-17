using System.ComponentModel.DataAnnotations;

namespace Bank.UI.Models.Account.Request
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
