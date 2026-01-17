using System.ComponentModel.DataAnnotations;

namespace Bank.UI.Models.Account.Request
{
    public class RegisterViewModel
    {
        [Required]
        public required string FullName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, MinLength(6)]
        public required string Password { get; set; }

        [Compare("Password")]
        public required string ConfirmPassword { get; set; }
    }
}
