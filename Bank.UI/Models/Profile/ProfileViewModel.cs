namespace Bank.UI.Models.Profile
{
    public class ProfileViewModel
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
