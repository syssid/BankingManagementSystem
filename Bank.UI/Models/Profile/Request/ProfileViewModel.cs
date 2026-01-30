using System.ComponentModel.DataAnnotations;

namespace Bank.UI.Models.Profile.Request
{
    public class ProfileViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
